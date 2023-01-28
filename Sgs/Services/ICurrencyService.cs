using Sgs.Models;

namespace Sgs.Services;

public interface ICurrencyService
{
    /// <summary>
    /// Получить список всех валют
    /// </summary>
    /// <param name="offset"> количество для пропуска валют от 0 </param>
    /// <param name="count"> количество валют, которое требуется получить </param>
    /// <returns>
    /// Количество валют с указанным offset и count. Если они не заполнены, то вернется
    /// все количество
    /// </returns>
    Dictionary<string, Currency> GetCurrencies(int? offset, int? count);

    /// <summary>
    /// Получение конкретной валюты по его коду
    /// </summary>
    /// <param name="code"> Код валюты </param>
    /// <returns> Валюта с указанным кодом </returns>
    Dictionary<string, Currency> GetCurrency(string code);
}