using System;
using System.Diagnostics;

namespace AssertionsHomework
{
    public static class ArraySorter
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array must not be a null");
            Debug.Assert(arr.Length > 0, "Array must not be empty");

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = ArraySearch.FindMinElementIndex(arr, index, arr.Length - 1);
                ArraySorter.Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }
    }
}
