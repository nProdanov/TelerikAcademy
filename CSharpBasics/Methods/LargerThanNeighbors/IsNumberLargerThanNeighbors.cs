using System;
class IsNumberLargerThanNeighbors
{
    static bool LargerThanNeighbors(int[] arr, int position)
    {
        if (position < 0 || position >= arr.Length)
        {
            return false;
        }
        else if (position==0)
        {
            if (arr[position]>arr[position+1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (position == arr.Length-1)
        {
            if (arr[position]>arr[position-1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if ((arr[position]>arr[position-1])&&(arr[position]>arr[position+1]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    static void Main()
    {
        int[] arr = { 2, 3, 4, 5, 1, 3, 2, 532, 234 };
        int position = int.Parse(Console.ReadLine());
        
        Console.WriteLine(LargerThanNeighbors(arr, position));
    }
}

