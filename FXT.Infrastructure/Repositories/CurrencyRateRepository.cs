using FXT.Domain.Entities;
using FXT.Domain.Repositories;
using FXT.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FXT.Infrastructure.Repositories
{
    public class CurrencyRateRepository : ICurrencyRateRepository
    {
        private readonly FXTimeSeriesDbContext _context;

        public CurrencyRateRepository(FXTimeSeriesDbContext context)
        {
            _context = context;
        }

        public FXTimeSeriesDbContext GetDbContext()
        {
            return _context;
        }

        public async Task<IEnumerable<CurrencyRate>> GetAllCurrencyRatesAsync()
        {
            return await _context.CurrencyRates.ToListAsync();
        }

        public async Task<IEnumerable<CurrencyRate>> GetRatesByCurrencyPairAsync(string currencyPair)
        {
            return await _context.CurrencyRates
                .Where(rate => rate.CurrencyPair == currencyPair)
                .ToListAsync();
        }

        public async Task<CurrencyRate> AddCurrencyRateAsync(CurrencyRate rate)
        {
            _context.CurrencyRates.Add(rate);
            await _context.SaveChangesAsync();
            return rate;
        }
    }
}
