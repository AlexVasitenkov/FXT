using FXT.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FXT.Domain.Repositories;

public interface ICurrencyRateRepository
{
    Task<IEnumerable<CurrencyRate>> GetAllCurrencyRatesAsync();
    Task<CurrencyRate> AddCurrencyRateAsync(CurrencyRate rate);
    Task<IEnumerable<CurrencyRate>> GetRatesByCurrencyPairAsync(string currencyPair);
    Task UpdateCurrencyRateAsync(CurrencyRate rate);
    Task DeleteCurrencyRateAsync(Guid id);

}

