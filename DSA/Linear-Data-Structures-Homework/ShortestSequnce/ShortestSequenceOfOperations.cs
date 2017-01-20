using System;
using System.Collections.Generic;

namespace ShortestSequnce
{
    public class ShortestSequenceOfOperations
    {
        public static void Main()
        {
            Console.WriteLine("Insert positive number N");
            int n = GetPositiveIntegerNumber();
            Console.WriteLine("Insert positive number M");
            int m = GetPositiveIntegerNumber();

            var sequence = GetShortestSequenceOfTransormsNToM(n, m);

            while (sequence.Count != 0)
            {
                Console.Write($"{sequence.Pop()}, ");
            }
        }

        // Available operations: N + 1, N + 2, N * 2
        public static Stack<int> GetShortestSequenceOfTransormsNToM(int n, int m)
        {
            if (n >= m)
            {
                Console.WriteLine("There is no sequence of N + 1, N + 2, N * 2 operations that can transform n to m");
            }

            var sequence = new Stack<int>();
            sequence.Push(m);

            int operatableNumber = m;
            while (operatableNumber > n)
            {
                if (operatableNumber / 2 >= n)
                {
                    operatableNumber /= 2;
                }
                else if (operatableNumber - 2 >= n)
                {
                    operatableNumber -= 2;
                }
                else if (operatableNumber - 1 >= 1)
                {
                    operatableNumber -= 1;
                }

                sequence.Push(operatableNumber);
            }

            return sequence;
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
