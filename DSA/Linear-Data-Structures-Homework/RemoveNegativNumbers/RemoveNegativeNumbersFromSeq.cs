using System;
using System.Collections.Generic;

namespace RemoveNegativeNumbers
{
    public class RemoveNegativeNumbersFromSeq
    {
        public static void Main()
        {
            var sequence = new List<int>() { 1, 2, 3, 5, 8, -1, 50, -10, 23, -1};

            var onlyPositiveNumbers = RemoveNegativeNumbers(sequence);

            Console.WriteLine("Positive numebrs of the sequence:");
            Console.WriteLine(string.Join(", ", onlyPositiveNumbers));
        }

        public static ICollection<int> RemoveNegativeNumbers(IEnumerable<int> sequence)
        {
            var onlyPositiveNumbers = new List<int>();

            foreach (var number in sequence)
            {
                if (number > 0)
                {
                    onlyPositiveNumbers.Add(number);
                }
            }

            return onlyPositiveNumbers;
        }
    }
}
