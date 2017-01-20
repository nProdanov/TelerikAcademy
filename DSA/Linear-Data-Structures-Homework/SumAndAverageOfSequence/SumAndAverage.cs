using System;
using System.Collections.Generic;
using System.Linq;

namespace SumAndAverageOfSequence
{
    public class SumAndAverage
    {
        public static void Main()
        {
            var sequence = new List<int>();

            while (true)
            {
                Console.WriteLine("Please insert a positive integer number");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                int inputNumber;

                try
                {
                    inputNumber = int.Parse(input);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                if (inputNumber <= 0)
                {
                    Console.WriteLine("Number is not positive number");
                    continue;
                }

                sequence.Add(inputNumber);
            }

            var sum = 0;
            for (int i = 0; i < sequence.Count; i++)
            {
                sum += sequence[i];
            }

            double average = sum / (double)sequence.Count;

            Console.WriteLine($"Sum of the sequence is {sum}, Average is {average}");
        }
    }
}
