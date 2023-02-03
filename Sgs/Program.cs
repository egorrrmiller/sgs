using Hangfire;
using Hangfire.MemoryStorage;
using Sgs.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

GlobalConfiguration.Configuration.UseMemoryStorage();
builder.Services.AddHangfire(x => x.UseMemoryStorage());
builder.Services.AddHangfireServer();

builder.Services.AddScoped<ICurrencyService, CurrencyService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHangfireDashboard("/jobs");
}

BackgroundJob.Enqueue(() => new CurrencyService().SetCurrencies());
RecurringJob.AddOrUpdate<CurrencyService>(x => x.SetCurrencies(), Cron.Daily(11, 35));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();