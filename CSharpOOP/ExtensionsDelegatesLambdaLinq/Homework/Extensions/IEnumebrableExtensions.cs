namespace Homework.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    using Students;

    public static class IEnumebrableExtensions
    {
        public static void PrintCollection<T>(this IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        public static T Sum<T>(this IEnumerable<T> collection)
                     where T : IConvertible, IComparable
        {
            ValidateCollCount(collection.Count());

            dynamic sum = 0;
            foreach (var item in collection)
            {
                sum += item;
            }

            return sum;
        }

        public static BigInteger Product<T>(this IEnumerable<T> collection)
        {
            ValidateCollCount(collection.Count());

            BigInteger product = 1;

            foreach (var item in collection)
            {
                product *= (dynamic)item;
            }

            return product;
        }

        public static T Min<T>(this IEnumerable<T> collection)
            where T : IConvertible, IComparable
        {
            ValidateCollCount(collection.Count());

            var min = collection.First();

            foreach (var item in collection)
            {
                if (min.CompareTo(item) > 0)
                {
                    min = item;
                }
            }

            return min;
        }

        public static T Max<T>(this IEnumerable<T> collection)
            where T : IComparable, IConvertible
        {
            ValidateCollCount(collection.Count());

            var max = collection.First();

            foreach (var item in collection)
            {
                if (max.CompareTo(item) < 0)
                {
                    max = item;
                }
            }

            return max;
        }

        public static double Average<T>(this IEnumerable<T> collection)
            where T : IComparable, IConvertible
        {
            double result = 0.0;
            result = (dynamic)collection.Sum() / collection.Count();
            return result;
        }

        private static void ValidateCollCount(int count)
        {
            if (count == 0)
            {
                throw new ArgumentException("Collection is empty");
            }
        }
    }
}
