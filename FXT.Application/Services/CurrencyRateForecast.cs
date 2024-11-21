namespace FXTimeSeries.Application.Services
{
    public class CurrencyRateForecast
    {
        // Метод для предсказания следующего курса на основе линейной регрессии
        public static double PredictNextRate(List<double> historicalRates)
        {
            if (historicalRates.Count < 2)
            {
                throw new ArgumentException("Not enough data for prediction");
            }

            double xSum = 0, ySum = 0, xySum = 0, xSquaredSum = 0;
            int n = historicalRates.Count;

            for (int i = 0; i < n; i++)
            {
                double x = i;
                double y = historicalRates[i];
                xSum += x;
                ySum += y;
                xySum += x * y;
                xSquaredSum += x * x;
            }

            double slope = (n * xySum - xSum * ySum) / (n * xSquaredSum - xSum * xSum);
            double intercept = (ySum - slope * xSum) / n;

            return slope * n + intercept;
        }
        // Метод для вычисления корня из среднеквадратичной ошибки  между фактическими и предсказанными значениями
        public static double CalculateRMSE(List<double> actualValues, List<double> predictedValues)
        {
            if (actualValues.Count != predictedValues.Count)
                throw new ArgumentException("Actual values and predicted values must have the same length");

            double sumSquaredError = 0;
            for (int i = 0; i < actualValues.Count; i++)
            {
                double error = actualValues[i] - predictedValues[i];
                sumSquaredError += error * error;
            }

            return Math.Sqrt(sumSquaredError / actualValues.Count);
        }
    }
}
