using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestSubsequence
{
    public class LongestSubSeq
    {
        public static void Main()
        {
            Console.WriteLine("Please enter the count of sequence:");
            int countOfNumbers = GetPositiveIntegerNumber();

            var sequence = new List<int>();

            for (int i = 0; i < countOfNumbers; i++)
            {
                Console.WriteLine("Enter positive integer number");
                sequence.Add(GetPositiveIntegerNumber());
            }

            var subSequence = GetSubsequenceOfEqualNumbers(sequence);

            Console.WriteLine("The Longest Subsequence of equal numbers is: ");
            Console.WriteLine(string.Join(", ", subSequence));
        }

        public static List<int> GetSubsequenceOfEqualNumbers(List<int> sequence)
        {
            int frequentNumber = sequence[0];
            int frequnce = 1;

            int mostFreaquentNumber = frequentNumber;
            int biggestFrequence = frequnce;
            for (int i = 1; i < sequence.Count; i++)
            {
                if (sequence[i] == sequence[i - 1])
                {
                    frequnce++;
                }
                else
                {
                    frequentNumber = sequence[i];
                    frequnce = 1;
                }

                if (biggestFrequence < frequnce)
                {
                    biggestFrequence = frequnce;
                    mostFreaquentNumber = frequentNumber;
                }
            }

            var subSequnce = new List<int>();
            for (int i = 0; i < biggestFrequence; i++)
            {
                subSequnce.Add(mostFreaquentNumber);
            }

            return subSequnce;
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
