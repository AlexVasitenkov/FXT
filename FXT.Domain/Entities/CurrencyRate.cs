using System;

namespace FXTimeSeries.Domain.Entities;

public class CurrencyRate
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string CurrencyPair { get; set; }
    public decimal Rate { get; set; }
}
