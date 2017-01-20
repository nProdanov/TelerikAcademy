using System;

namespace Methods
{
    public class StartPoint
    {
        public static void Main()
        {
            Console.WriteLine(HelpMethods.CalcTriangleArea(3, 4, 5));

            Console.WriteLine(HelpMethods.ConvertDigitToText(5));

            Console.WriteLine(HelpMethods.FindMaxNumber(5, -1, 3, 2, 14, 2, 3));

            HelpMethods.PrintNumberAsFloating(1.3, 4);
            HelpMethods.PrintNumberAsPercentage(0.75);
            HelpMethods.PrintNumberPaddedLeft(2.30, 10);

            var pointOne = new Point2D(3, 4);
            var pointTwo = new Point2D(5, 4);
            Console.WriteLine(HelpMethods.CalcDistance(pointOne, pointTwo));
            Console.WriteLine("Horizontal? " + HelpMethods.IsHorizontal(pointOne, pointTwo));
            Console.WriteLine("Vertical? " + HelpMethods.IsVertical(pointOne, pointTwo));

            Student peter = new Student(
                "Peter",
                "Ivanov",
                "From Sofia, born at 17.03.1992");

            Student stella = new Student(
                "Stella",
                "Markova",
                "From Vidin, gamer, high results, born at 03.11.1993");

            Console.WriteLine(
                "{0} older than {1} -> {2}",
                peter.FirstName,
                stella.FirstName,
                peter.IsOlderThan(stella));
        }
    }
}
