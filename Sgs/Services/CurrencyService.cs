using Newtonsoft.Json;
using Sgs.Models;

namespace Sgs.Services;

public class CurrencyService : ICurrencyService
{
    private static Dictionary<string, Currency> _currencies = new();

    private readonly HttpClient _client = new();

    public Dictionary<string, Currency> GetCurrencies(int? offset, int? count)
    {
        var currency = _currencies;
        var result = currency.Skip(offset ?? 0).Take(count ?? currency.Count);

        return result.ToDictionary(x => x.Key, x => x.Value);
    }

    public Dictionary<string, Currency> GetCurrency(string code)
    {
        return _currencies.Where(x => x.Key == code).ToDictionary(x => x.Key, x => x.Value);
    }

    public async Task SetCurrencies()
    {
        var result = await _client.GetAsync("https://www.cbr-xml-daily.ru/daily_json.js")
            .GetAwaiter()
            .GetResult()
            .Content.ReadAsStringAsync();

        _currencies = JsonConvert.DeserializeObject<Main>(result).Valute;
    }
}