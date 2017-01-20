using System;
using System.Collections.Generic;

namespace ReverseNumbers
{
    public class ReverseNumbers
    {
        public static void Main()
        {
            Console.WriteLine("Please enter how many numbers you want to reverese");
            int countOfNumbers = GetPositiveIntegerNumber();

            var sequence = new Stack<int>();

            for (int i = 0; i < countOfNumbers; i++)
            {
                Console.WriteLine("Enter positive integer number");
                sequence.Push(GetPositiveIntegerNumber());
            }

            Console.WriteLine("Numbers in reversed order");
            for (int i = 0; i < countOfNumbers; i++)
            {
                Console.WriteLine(sequence.Pop());
            }
        }

        public static int GetPositiveIntegerNumber()
        {

            while (true)
            {
                int inputNumber = 0;

                try
                {
                    inputNumber = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input");
                }

                if (inputNumber <= 0)
                {
                    Console.WriteLine("Number must be positive");
                    continue;
                }

                return inputNumber;
            }
        }
    }
}
