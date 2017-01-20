using System;
class BitsSwap
{
    public static bool GetBit(long number, byte position)
    {
        long mask = (long)1 << position;
        mask = number & mask;
        if (mask > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public static long ChangeBit(long number, bool bit, byte position)
    {
        long mask = 1;
        mask = mask << position;
        if (bit)
        {
            return number | mask;
        }
        else
        {
            return number & ~mask;
        }
    }
    static void Main()

        //Write a program first reads 3 numbers n, p, q and k and than swaps bits {p, p+1, …, p+k-1} with 
        //bits {q, q+1, …, q+k-1} of n. Print the resulting integer on the console.


    {
        long number = long.Parse(Console.ReadLine());
        byte p = byte.Parse(Console.ReadLine());
        byte q = byte.Parse(Console.ReadLine());
        byte k = byte.Parse(Console.ReadLine());
        int border = q + k - 1;
        int start = q;

        for (int i = start; i <= border; i++)
        {
            bool first = GetBit(number,p);
            bool second = GetBit(number,q);
            number = ChangeBit(number, first, q);
            number = ChangeBit(number, second, p);
            q++;
            p++;
            
            
        }
        Console.WriteLine(number);
    }
}

