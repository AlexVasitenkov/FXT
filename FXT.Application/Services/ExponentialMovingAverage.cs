namespace FXTimeSeries.Application.Services
{
    public class ExponentialMovingAverage
    {
        // Метод для вычисления экспоненциального сглаживания.
        public static List<double> CalculateEMA(List<double> data, double smoothingFactor)
        {
            if (data == null || data.Count == 0)
            {
                throw new ArgumentException("Data cannot be empty");
            }

            List<double> emaValues = new List<double>();
            double ema = data[0];

            // Для каждого значения в данных вычисляем EMA
            foreach (var value in data)
            {
                ema = (value * smoothingFactor) + (ema * (1 - smoothingFactor));
                emaValues.Add(ema);
            }

            return emaValues;
        }
    }
}
