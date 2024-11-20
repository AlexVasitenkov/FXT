using FXT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FXT.Domain.Repositories
{

    public interface IPredictionRepository
    {
        Task<IEnumerable<Prediction>> GetAllPredictionsAsync();
        Task<Prediction> AddPredictionAsync(Prediction prediction);
        Task<Prediction> GetPredictionByIdAsync(Guid id);
    }
}
