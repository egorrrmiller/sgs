using Microsoft.AspNetCore.Mvc;
using Sgs.Models;
using Sgs.Services;

namespace Sgs.Controllers;

[ApiController]
public class CurrencyController : ControllerBase
{
    private readonly ICurrencyService _currencyService;

    public CurrencyController(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }

    [HttpGet("/currencies")]
    public Dictionary<string, Currency> GetCurrencies(int? offset, int? count)
    {
        return _currencyService.GetCurrencies(offset, count);
    }

    [HttpGet("/currency")]
    public Dictionary<string, Currency> GetCurrency(string code)
    {
        return _currencyService.GetCurrency(code);
    }
}