using FXT.Domain.Entities;

namespace FXT.Application.Services
{
    public interface ICurrencyRateService
    {
        Task<IEnumerable<CurrencyRate>> GetCurrencyRatesAsync();
        Task<CurrencyRate> AddCurrencyRateAsync(CurrencyRate rate);
        Task<decimal> GetCurrencyRatePredictionUsingMovingAverageAsync(string currencyPair, int windowSize);
        Task<decimal> GetCurrencyRatePredictionUsingEMAAsync(string currencyPair, int period);

        Task UpdateCurrencyRateAsync(CurrencyRate rate);
        Task DeleteCurrencyRateAsync(Guid id);

    }

}
