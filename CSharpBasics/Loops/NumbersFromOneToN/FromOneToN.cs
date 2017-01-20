using System;
class FromOneToN
{
    static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
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

