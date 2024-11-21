using FXT.Domain.Entities;
using FXT.Domain.Repositories;
using FXT.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class CurrencyRateRepository : ICurrencyRateRepository
{
    private readonly FXTimeSeriesDbContext _context;

    public CurrencyRateRepository(FXTimeSeriesDbContext context)
    {
        _context = context;
    }
    public async Task UpdateCurrencyRateAsync(CurrencyRate rate)
    {
        _context.CurrencyRates.Update(rate);
        await _context.SaveChangesAsync();
    }


    public async Task<IEnumerable<CurrencyRate>> GetAllCurrencyRatesAsync()
    {
        return await _context.CurrencyRates.ToListAsync();
    }

    public async Task<CurrencyRate> AddCurrencyRateAsync(CurrencyRate rate)
    {
        _context.CurrencyRates.Add(rate);
        await _context.SaveChangesAsync();
        return rate;
    }

    public async Task<IEnumerable<CurrencyRate>> GetRatesByCurrencyPairAsync(string currencyPair)
    {
        return await _context.CurrencyRates
            .Where(rate => rate.CurrencyPair == currencyPair)
            .ToListAsync();
    }

    

    public async Task DeleteCurrencyRateAsync(Guid id)
    {
        var rate = await _context.CurrencyRates.FindAsync(id);
        if (rate != null)
        {
            _context.CurrencyRates.Remove(rate);
            await _context.SaveChangesAsync();
        }
    }

}
