namespace FXTimeSeries.Application.DTOs
{
    // Класс для данных, которые отправляем при создании прогноза
    public class CreatePredictionRequestDto
    {
        public string CurrencyPair { get; set; }
        public int DaysAhead { get; set; }
    }
}
