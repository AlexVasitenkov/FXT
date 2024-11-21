namespace FXTimeSeries.Application.DTOs
{
    // DTO для прогноз курса валют
    public class PredictionDto
    {
        public Guid Id { get; set; }
        public string CurrencyPair { get; set; }
        public DateTime PredictionDate { get; set; }
        public decimal PredictedRate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
