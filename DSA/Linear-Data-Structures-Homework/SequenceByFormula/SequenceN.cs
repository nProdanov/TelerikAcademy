using System;
using System.Collections.Generic;

namespace SequenceByFormula
{
    public class SequenceN
    {
        public static void Main()
        {
            PrintFiftyNumbersByN(2);
        }

        public static void PrintFiftyNumbersByN(int n)
        {
            int numbersCount = 50;
            var sequence = new Queue<int>();
            sequence.Enqueue(n);

            int counter = 1;
            int printedNumbersCount = 0;
            while (true)
            {
                var number = sequence.Dequeue();
                Console.Write($"{number}, ");
                printedNumbersCount++;

                if (counter >= numbersCount)
                {
                    break;
                }

                sequence.Enqueue(number + 1);
                sequence.Enqueue(2 * number + 1);
                sequence.Enqueue(number + 2);

                counter += 3;
            }

            for (int i = 0; i < numbersCount - printedNumbersCount; i++)
            {
                Console.Write($"{sequence.Dequeue()}, ");
            }
        }
    }
}
