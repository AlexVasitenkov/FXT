using System;

namespace FXT.Domain.Entities
{
    public class CurrencyRate
    {
        private decimal _rate;

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string CurrencyPair { get; set; }

        public decimal Rate
        {
            get => _rate;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Rate), "Ставка должна быть больше нуля");
                }
                _rate = value;
            }
        }
    }
}
