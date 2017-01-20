using System;

    class Sequence

    {
        static void Main()
        {
            int num = 1;
            for (int i = 0; i < 10; i++)
            {
                num++;
                if (num%2==0)
                {
                    Console.WriteLine(num);
                }
                else
                {
                    Console.WriteLine(-num);
                }
            }
        }
    }

