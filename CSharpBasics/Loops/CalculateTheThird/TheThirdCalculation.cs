using System;
using System.Numerics;
class TheThirdCalculation
{
    static void Main()
    {
        int bigger = int.MinValue;
        int n = int.Parse(Console.ReadLine());
        if (n > bigger)
        {
            bigger = n;
        }
        int k = int.Parse(Console.ReadLine());
        if (k > bigger)
        {
            bigger = k;
        }
        int nMinusK = n - k;
        BigInteger factorielN = 1;
        BigInteger factorielK = 1;
        BigInteger factorielNMinusK = 1;


        for (int i = 1; i <= bigger; i++)
        {
            if (n >= i)
            {
                factorielN *= i;
            }
            if (k >= i)
            {
                factorielK *= i;
            }
            if (nMinusK>=i)
            {
                factorielNMinusK *= i;
            }
        }
        BigInteger combinatoricsFormula = factorielN /( factorielK * factorielNMinusK);

        Console.WriteLine(combinatoricsFormula);
    }
}

