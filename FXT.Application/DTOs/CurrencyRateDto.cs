namespace FXTimeSeries.Application.DTOs
{

    public class CurrencyRateDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string CurrencyPair { get; set; }
        public decimal Rate { get; set; }
    }
}
