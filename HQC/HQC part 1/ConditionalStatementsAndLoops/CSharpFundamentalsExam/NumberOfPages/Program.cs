namespace NumberOfPages
{
    using System;
    using System.Numerics;

    public class Program
    {
        public static void Main()
        {
            FindPages();
        }

        public static void FindPages()
        {
            int pages = int.Parse(Console.ReadLine());

            BigInteger digitsNeededToWriteThePages = 0;

            for (int i = 1; i <= pages; i++)
            {
                if (i < 10)
                {
                    digitsNeededToWriteThePages++;
                }
                else if (9 < i && i < 100)
                {
                    digitsNeededToWriteThePages += 2;
                }
                else if (99 < i && i < 1000)
                {
                    digitsNeededToWriteThePages += 3;
                }
                else if (999 < i && i < 10000)
                {
                    digitsNeededToWriteThePages += 4;
                }
                else if (9999 < i && i < 100000)
                {
                    digitsNeededToWriteThePages += 5;
                }
                else if (99999 < i && i < 1000000)
                {
                    digitsNeededToWriteThePages += 6;
                }
            }

            Console.WriteLine(digitsNeededToWriteThePages);
        }
    }
}
