using System;
using System.Collections.Generic;

namespace SortingInIncreasingOrder
{
    public class Sorting
    {
        public static void Main()
        {
            var sequence = new List<int>();
            while (true)
            {
                Console.WriteLine("Please insert positive integer number");
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                int numberToAdd = GetPositiveIntegerNumber(input);
                if (numberToAdd < 0)
                {
                    break;
                }

                sequence.Add(numberToAdd);
            }

            SortAscending(sequence);

            foreach (var number in sequence)
            {
                Console.WriteLine(number);
            }

        }

        public static void SortAscending(IList<int> sequence)
        {
            for (int j = 0; j < sequence.Count; j++)
            {
                int min = int.MaxValue;
                int minIndex = 0;
                for (int i = j; i < sequence.Count; i++)
                {
                    int currentNumber = sequence[i];
                    if (currentNumber < min)
                    {
                        min = currentNumber;
                        minIndex = i;
                    }
                }

                sequence[minIndex] = sequence[j];
                sequence[j] = min;
            }
        }

        public static int GetPositiveIntegerNumber(string input)
        {
            while (true)
            {
                input = input ?? Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    return -1;
                }

                int countOfNumbers = 0;

                try
                {
                    countOfNumbers = int.Parse(input);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input");
                }

                if (countOfNumbers <= 0)
                {
                    Console.WriteLine("Number must be positive");
                    input = null;
                    continue;
                }

                return countOfNumbers;
            }
        }
    }
}
