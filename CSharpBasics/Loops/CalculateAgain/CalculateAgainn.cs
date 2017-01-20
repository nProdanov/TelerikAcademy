using System;
using System.Numerics;

class CalculateAgainn
{
    static void Main()
    {
        int bigger = int.MinValue;
        int n = int.Parse(Console.ReadLine());
        if (n>bigger)
        {
            bigger = n;
        }
        int k = int.Parse(Console.ReadLine());
        if (k>bigger)
        {
            bigger = k;
        }
        BigInteger factorielN = 1;
        BigInteger factorielK = 1;
        
        
        for (int i = 1; i <= bigger; i++)
        {
            if (n >= i)
            {
                factorielN *= i;
            }
            if (k>=i)
            {
                factorielK *= i;
            }
        }
        BigInteger devision = factorielN / factorielK;
        Console.WriteLine(devision);
     }
}

