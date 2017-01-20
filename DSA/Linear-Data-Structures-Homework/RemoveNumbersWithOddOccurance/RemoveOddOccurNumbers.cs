using System.Collections.Generic;

namespace RemoveNumbersWithOddOccurance
{
    public class RemoveOddOccurNumbers
    {
        public static void Main()
        {
            var sequence = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            RemoveNumbersThatOccurOddTimes(sequence);

            System.Console.WriteLine(string.Join(", ", sequence));
        }

        public static void RemoveNumbersThatOccurOddTimes(List<int> sequence)
        {
            var copy = new List<int>();
            sequence.ForEach(number => copy.Add(number));

            copy.Sort();
            var occurance = 1;

            for (int i = 1; i < copy.Count; i++)
            {
                if (copy[i] != copy[i-1])
                {
                    if (occurance % 2 != 0)
                    {
                        sequence.RemoveAll(number => number == copy[i-1]);
                    }

                    occurance = 1;
                }
                else
                {
                    occurance++;
                }
            }
        }
        
    }
}
