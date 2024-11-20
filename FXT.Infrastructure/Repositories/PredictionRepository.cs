using FXT.Domain.Entities;
using FXT.Domain.Repositories;
using FXT.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class PredictionRepository : IPredictionRepository
{
    private readonly FXTimeSeriesDbContext _context;

    public PredictionRepository(FXTimeSeriesDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Prediction>> GetAllPredictionsAsync()
    {
        return await _context.Predictions.ToListAsync(); // Получаем все прогнозы
    }

    public async Task<Prediction> AddPredictionAsync(Prediction prediction)
    {
        await _context.Predictions.AddAsync(prediction);
        await _context.SaveChangesAsync();
        return prediction;
    }

    public async Task<Prediction> GetPredictionByIdAsync(Guid id)
    {
        return await _context.Predictions.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

}


