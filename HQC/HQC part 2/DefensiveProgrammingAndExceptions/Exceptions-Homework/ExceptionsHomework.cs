using System;
using System.Collections.Generic;

using ExceptionsHomework.Extensions;
using ExceptionsHomework.Models;
using ExceptionsHomework.Models.Exams;
using ExceptionsHomework.Models.Exams.Contracts;

namespace ExceptionsHomework
{
    public class ExceptionsHomework
    {
        public const string Separator = "--------------------";

        public static void Main()
        {
            var charCollection = "Hello!".ToCharArray();
            var subseqCharCollection = charCollection.Subsequence(2, 3);
            Console.WriteLine(subseqCharCollection);

            var numbers = new int[] { -1, 3, 2, 1 };
            var subseqNumbers = numbers.Subsequence(0, 2);
            Console.WriteLine(string.Join(" ", subseqNumbers));

            var subseqOfAllNumbers = numbers.Subsequence(0, 4);
            Console.WriteLine(string.Join(" ", subseqOfAllNumbers));

            var emptySubseqOfNumbers = numbers.Subsequence(0, 0);
            Console.WriteLine(string.Join(" ", emptySubseqOfNumbers));

            Console.WriteLine(Separator);

            Console.WriteLine("I love C#".ExtractEnding(2));
            Console.WriteLine("Nakov".ExtractEnding(4));
            Console.WriteLine("beer".ExtractEnding(4));
            Console.WriteLine("Hi".ExtractEnding(100)); // cause an Exception

            Console.WriteLine(Separator);

            var numberTwentyThree = 23;
            Console.WriteLine(string.Format("{0} is prime -> {1}", numberTwentyThree, numberTwentyThree.CheckIfPrimeNumber()));
            var numberThirtyThree = 33;
            Console.WriteLine(string.Format("{0} is prime -> {1}", numberThirtyThree, numberThirtyThree.CheckIfPrimeNumber()));

            Console.WriteLine(Separator);

            List<IExam> peterExams = new List<IExam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };

            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}