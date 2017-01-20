using System;
using System.Numerics;

class CatalanNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int doubleN = 2 * n;
        int nPlusOne = n + 1;
        BigInteger faktorielN = 1;
        BigInteger faktorielDoubleN = 1;
        BigInteger faktorielNplusOne = 1;

        for (int i = 1; i <= doubleN; i++)
        {
            if (n>=i)
            {
                faktorielN *= i;
            }
            if (doubleN>=i)
            {
                faktorielDoubleN *= i;
            }
            if (nPlusOne>=i)
            {
                faktorielNplusOne *= i;
            }
        }
        BigInteger catalanNumber = faktorielDoubleN / (faktorielN * faktorielNplusOne);
        Console.WriteLine(catalanNumber);
    }
}

