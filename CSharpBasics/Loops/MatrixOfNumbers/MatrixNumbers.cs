using System;
class MatrixNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int count = 1;
        int current = 1;
        int backcount = n;

        while (count<=n)
        {
            if (backcount >= 1)
            {
                Console.Write("{0} ",current);
                current++;
                backcount--;
            }
            else
            {
                Console.WriteLine();
                count++;
                current = count;
                backcount = n;
            }

        }
    }
}

