using System;
class NumbersNotDevisibleThreeOrSeven
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            if (i%3!=0 && i%7!=0)
            {
                if (i == n)
                {
                    Console.WriteLine("{0}",i);
                }
                else
                {
                    Console.Write("{0} ", i);

                }
            } 
        }
    }
}

