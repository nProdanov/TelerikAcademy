using System;
    class EvenOrOdd
    {
        static void Main( )
        {
            int number = int.Parse(Console.ReadLine());
            string odd = "odd";
            string even = "even";
            if (number % 2 == 0)
            {
                Console.WriteLine("{0} {1}",even,number);
            }
            else
            {
                Console.WriteLine("{0} {1}",odd, number);
            }
        }
    }

