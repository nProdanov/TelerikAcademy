using System;
using System.Linq;
using System.Diagnostics;

public class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array must not be a null");
        Debug.Assert(arr.Length > 0, "Array must not be empty");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
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

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array must not be a null");
        Debug.Assert(arr.Length > 0, "Array must not be empty");
        Debug.Assert(
            arr
            .Zip(arr.Skip(1), (first, second) => first.CompareTo(second) <= 0)
            .All(x => x == true),
            "Array must be sorted ascending to produce binary search on it");


        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array must not be a null");
        Debug.Assert(arr.Length > 0, "Array must not be empty");
        Debug.Assert(startIndex >= 0, "Start index must be equal or greater than index of first element in the array");
        Debug.Assert(endIndex < arr.Length, "End index should be equal or less than index of last element in the array");
        Debug.Assert(startIndex < endIndex, "Start index must always be smaller than a End index");

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

        // Searched value not found
        return -1;
    }

    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        //SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}
