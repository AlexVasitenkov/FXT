using FXT.Application.Services;
using FXT.Domain.Entities;
using FXT.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

public class CurrencyRateService : ICurrencyRateService
{
    private readonly ICurrencyRateRepository _currencyRateRepository;

    // Конструктор, в котором передается репозиторий курсов валют
    public CurrencyRateService(ICurrencyRateRepository currencyRateRepository)
    {
        _currencyRateRepository = currencyRateRepository;
    }

    // Метод для предсказания курса валют с использованием скользящего среднего
    public async Task<decimal> GetCurrencyRatePredictionUsingMovingAverageAsync(string currencyPair, int windowSize)
    {
        var rates = await _currencyRateRepository.GetRatesByCurrencyPairAsync(currencyPair);
        var recentRates = rates.Reverse().Take(windowSize).Reverse().ToList();
        decimal movingAverage = recentRates.Average(rate => rate.Rate);
        return movingAverage;
    }

    // Метод для прогнозирования курса валют с использованием экспоненциального сглаживания
    public async Task<decimal> GetCurrencyRatePredictionUsingEMAAsync(string currencyPair, int period)
    {
        var rates = await _currencyRateRepository.GetRatesByCurrencyPairAsync(currencyPair);
        decimal smoothingConstant = 2.0m / (period + 1);
        decimal ema = rates.First().Rate;

        foreach (var rate in rates.Skip(1))
        {
            ema = smoothingConstant * rate.Rate + (1 - smoothingConstant) * ema;
        }

        return ema;
    }

    // Метод для добавления курса валют
    public async Task<CurrencyRate> AddCurrencyRateAsync(CurrencyRate rate)
    {
        return await _currencyRateRepository.AddCurrencyRateAsync(rate);
    }

    // Метод для получения всех курсов валют (реализация отсутствующего метода интерфейса)
    public async Task<IEnumerable<CurrencyRate>> GetCurrencyRatesAsync()
    {
        return await _currencyRateRepository.GetAllCurrencyRatesAsync();
    }

    public async Task UpdateCurrencyRateAsync(CurrencyRate rate)
    {
        await _currencyRateRepository.UpdateCurrencyRateAsync(rate);
    }

    public async Task DeleteCurrencyRateAsync(Guid id)
    {
        await _currencyRateRepository.DeleteCurrencyRateAsync(id);
    }

}
