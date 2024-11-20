using FXT.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FXT.Domain.Repositories;

public interface ICurrencyRateRepository
{
    Task<IEnumerable<CurrencyRate>> GetAllCurrencyRatesAsync();
    Task<IEnumerable<CurrencyRate>> GetRatesByCurrencyPairAsync(string currencyPair);
    Task<CurrencyRate> AddCurrencyRateAsync(CurrencyRate rate);
}
