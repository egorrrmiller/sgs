namespace Sgs.Models;

public record Currency(string ID,
                       string NumCode,
                       string CharCode,
                       int Nominal,
                       string Name,
                       double Value,
                       double Previous);

public record Main(DateTime Date,
                   DateTime PreviousDate,
                   string PreviousURL,
                   DateTime Timestamp,
                   Dictionary<string, Currency> Valute);