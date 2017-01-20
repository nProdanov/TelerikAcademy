namespace VariablesDataExpressionsConstants.PrintStatistics
{
    using System;

    public class Printer
    {
        public void PrintMax(double[] collection, int collectionCount)
        {
            double max = Calculations.GetMax(collection, collectionCount);
            Console.WriteLine(max);
        }

        public void PrintMin(double[] collection, int collectionCount)
        {
            double min = Calculations.GetMin(collection, collectionCount);
            Console.WriteLine(min);
        }

        public void PrintAverage(double[] collection, int collectionCount)
        {
            double average = Calculations.GetAverage(collection, collectionCount);
            Console.WriteLine(average);
        }
    }
}
