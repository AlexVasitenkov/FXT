using System;

namespace FXT.Domain.Entities
{
    public class Prediction
    {
        public Guid Id { get; set; }
        public string CurrencyPair { get; set; }
        public decimal PredictedRate { get; set; }
        public DateTime Date { get; set; }
    }
}