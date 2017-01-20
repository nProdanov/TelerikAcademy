using System;
using System.Numerics;
class TrailingZeroes
{
    static void Main()
    {
      
        int n = int.Parse(Console.ReadLine());
        int result = 0;
        int start = 1;
        while (n >= start)
        {
            start *= 5;
            result += (int)n / start;
        }
        Console.WriteLine(result);
    }
}

