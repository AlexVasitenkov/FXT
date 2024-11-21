using FXT.Domain.Entities;
using FXT.Domain.Repositories;

//
public class PredictionService
{
    private readonly IPredictionRepository _currencyRateRepository;

    public PredictionService(IPredictionRepository currencyRateRepository)
    {
        _currencyRateRepository = currencyRateRepository;
    }

    public async Task<Prediction> AddPredictionAsync(Prediction prediction)
    {
        return await _currencyRateRepository.AddPredictionAsync(prediction);
    }

    public async Task<List<Prediction>> GetAllPredictionsAsync()
    {
        return (List<Prediction>)await _currencyRateRepository.GetAllPredictionsAsync();
    }

}
