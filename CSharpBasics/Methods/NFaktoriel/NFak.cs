using System;
class NFak
{
    static void Main()
    {
        long[] arr = new long[100];
        arr[0] = 1;
        for (int i = 1; i <= arr.Length-1; i++)
        {
            arr[i] = arr[i-1] * i;
        }

    }

}

