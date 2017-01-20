using System;

namespace AssertionsHomework
{
    public class ArrayOperationsExample
    {
        public static void Main()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));

            ArraySorter.SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            ArraySorter.SelectionSort(new int[0]); // Test sorting empty array
            ArraySorter.SelectionSort(new int[1]); // Test sorting single element array

            ArraySearch.BinarySearch(new int[] { 4, 3, 1 }, 3); // Test binary search with non sorted array

            Console.WriteLine("Binary search results:");
            Console.WriteLine(ArraySearch.BinarySearch(arr, -1000));
            Console.WriteLine(ArraySearch.BinarySearch(arr, 0));
            Console.WriteLine(ArraySearch.BinarySearch(arr, 17));
            Console.WriteLine(ArraySearch.BinarySearch(arr, 10));
            Console.WriteLine(ArraySearch.BinarySearch(arr, 1000));
        }
    }
}