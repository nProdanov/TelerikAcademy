using System;
using System.Collections.Generic;

namespace MajorantOfAnArray
{
    public class MajorantOfAnArray
    {
        public static void Main()
        {
            var sequence = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 }; 

            var majorant = FindMajorantOfAnArray(sequence);

            if (majorant < 0)
            {
                Console.WriteLine("There is no majorant in the sequence");
            }
            else
            {
                Console.WriteLine($"The biggest majorant for the sequnce is: {majorant}");
            }
        }

        public static int FindMajorantOfAnArray(int[] sequence)
        {
            var occurances = new Dictionary<int, int>();

            foreach (var number in sequence)
            {
                if (occurances.ContainsKey(number))
                {
                    occurances[number]++;
                }
                else
                {
                    occurances[number] = 1;
                }
            }

            var smallestMajorantCount = sequence.Length / 2 + 1;

            var majorant = -1;
            foreach (var item in occurances)
            {
                if (item.Value >= smallestMajorantCount)
                {
                        majorant = item.Key;
                }
            }

            return majorant;
        }
    }
}
