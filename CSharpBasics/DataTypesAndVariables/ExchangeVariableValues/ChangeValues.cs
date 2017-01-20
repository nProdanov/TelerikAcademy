using System;
    class ChangeValues
    {
        static void Main()
        {
            int a = 5;
            int b = 10;
            Console.WriteLine(a);
            a += b;
            Console.WriteLine(b);
            b = a - b;
            a = a - b;
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }

