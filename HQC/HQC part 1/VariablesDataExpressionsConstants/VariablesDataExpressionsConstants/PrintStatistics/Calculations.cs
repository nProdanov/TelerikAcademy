namespace VariablesDataExpressionsConstants.PrintStatistics
{
    internal static class Calculations
    {
        internal static double GetMax(double[] collection, int collectionCount)
        {
            double max = double.MinValue;

            for (int i = 0; i < collectionCount; i++)
            {
                if (collection[i] > max)
                {
                    max = collection[i];
                }
            }

            return max;
        }

        internal static double GetMin(double[] collection, int collectionCount)
        {
            double min = double.MaxValue;

            for (int i = 0; i < collectionCount; i++)
            {
                if (min > collection[i])
                {
                    min = collection[i];
                }
            }

            return min;
        }

        internal static double GetSum(double[] collection, int collectionCount)
        {
            double sum = 0;

            for (int i = 0; i < collectionCount; i++)
            {
                sum += collection[i];
            }

            return sum;
        }

        internal static double GetAverage(double[] collection, int collectionCount)
        {
            double sum = GetSum(collection, collectionCount);
            double average = sum / collectionCount;

            return average;
        }
    }
}
