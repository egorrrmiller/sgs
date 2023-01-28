using Newtonsoft.Json;
using Sgs.Models;

namespace Sgs.Services;

public class CurrencyService : ICurrencyService
{
    private readonly HttpClient _client = new();

    public Dictionary<string, Currency> GetCurrencies(int? offset, int? count)
    {
        var rates = CurrencyModel.Currencies;
        var result = rates.Skip(offset ?? 0).Take(count ?? rates.Count);

        return result.ToDictionary(x => x.Key, x => x.Value);
    }

    public Dictionary<string, Currency> GetCurrency(string code)
    {
        return CurrencyModel.Currencies.Where(x => x.Key == code).ToDictionary(x => x.Key, x => x.Value);
    }

    public async Task SetCurrencies()
    {
        var result = await _client.GetAsync("https://www.cbr-xml-daily.ru/daily_json.js")
            .GetAwaiter()
            .GetResult()
            .Content.ReadAsStringAsync();

        CurrencyModel.Currencies = JsonConvert.DeserializeObject<Main>(result).Valute;
    }
}