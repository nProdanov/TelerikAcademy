using System;
using System.Collections.Generic;

namespace BelongToRange
{
    public class OccuranceOfNumbers
    {
        public static void Main()
        {
            int[] sequence = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            var numbersAndOccurances = GetNumbersAndOccurancesInRange(sequence, 0, 1000);

            foreach (var pair in numbersAndOccurances)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value} times");
            }
        }

        public static IDictionary<int, int> GetNumbersAndOccurancesInRange(int[] sequence, int minRangeValue, int maxRangeValue)
        {
            var numbersAndOccurances = new Dictionary<int, int>();

            for (int i = 0; i < sequence.Length; i++)
            {
                var currentNumber = sequence[i];
                if (minRangeValue <= currentNumber && currentNumber <= maxRangeValue)
                {
                    if (numbersAndOccurances.ContainsKey(currentNumber))
                    {
                        numbersAndOccurances[currentNumber]++;
                    }
                    else
                    {
                        numbersAndOccurances[currentNumber] = 1;
                    }
                }
            }

            return numbersAndOccurances;
        }
    }
}
