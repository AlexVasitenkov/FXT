namespace FXTimeSeries.Application.Services
{
    public class MovingAverage
    {

        public static List<double> CalculateMovingAverage(List<double> data, int windowSize)
        {
            if (data == null || data.Count < windowSize)
            {
                throw new ArgumentException("Data size must be greater than or equal to the window size.");
            }

            List<double> movingAverages = new List<double>();
            double sum = 0;

            for (int i = 0; i < data.Count; i++)
            {
                sum += data[i];
                if (i >= windowSize)
                {
                    sum -= data[i - windowSize];
                }
                if (i >= windowSize - 1)
                {
                    movingAverages.Add(sum / windowSize);
                }
            }

            return movingAverages;
        }
    }
}
