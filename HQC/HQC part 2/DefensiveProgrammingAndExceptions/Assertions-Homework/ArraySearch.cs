using System;
using System.Diagnostics;
using System.Linq;

namespace AssertionsHomework
{
    public static class ArraySearch
    {
        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array must not be a null");
            Debug.Assert(arr.Length > 0, "Array must not be empty");
            Debug.Assert(
                arr
                .Zip(arr.Skip(1), (first, second) => first.CompareTo(second) <= 0)
                .All(x => x == true),
                "Array must be sorted ascending to produce binary search on it");

            int startIndex = 0;
            int endIndex = arr.Length - 1;

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }
            
            return -1;
        }

        public static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array must not be a null");
            Debug.Assert(arr.Length > 0, "Array must not be empty");
            Debug.Assert(startIndex >= 0, "Start index must be equal or greater than index of first element in the array");
            Debug.Assert(endIndex < arr.Length, "End index should be equal or less than index of last element in the array");
            Debug.Assert(startIndex < endIndex, "Start index must always be smaller than an End index");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            return minElementIndex;
        }
    }
}
