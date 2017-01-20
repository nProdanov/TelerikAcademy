using System;
class SortArray
{
    static int[] Sort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int maxPos = PositionOfMaxInArray(arr, i);
            int current = arr[i];
            arr[i] = arr[maxPos];
            arr[maxPos] = current;

        }
        return arr;
    }

    static int PositionOfMaxInArray(int[] arr, int startPos)
    {
        int max = int.MinValue;
        int maxPos = 0;
        for (int i = startPos; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
                maxPos = i;
            }
           
        }
        return maxPos;
    }
    static void Main()
    {
        int[] arr = { 2, 5, 7, 32, 645, 23, 11, 66 };
        Sort(arr);
        foreach (int item in arr)
        {
            Console.Write("{0} ",item);
        }
    }
}

