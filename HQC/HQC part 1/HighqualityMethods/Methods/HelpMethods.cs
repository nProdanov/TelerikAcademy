using System;
using System.Globalization;

namespace Methods
{
    internal static class HelpMethods
    {
        internal static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Each side of triangle must be a positive number");
            }

            if (a + b <= c || a + c <= b || b + c <= a)
            {
                throw new ArgumentException("Each sum of two sides must be greater than the third side");
            }

            double halfPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));

            return area;
        }

        internal static string ConvertDigitToText(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentOutOfRangeException("Digits are in range 0 - 9");
            }
        }

        internal static int FindMaxNumber(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("The array of elements must not be null or empty");
            }

            var max = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (max < elements[i])
                {
                    max = elements[i];
                }
            }

            return max;
        }

        internal static void PrintNumberPaddedRight(double number, int countSpacesPadded)
        {
            if (countSpacesPadded < 0)
            {
                throw new ArgumentException("Right padding symbols must be a positive number");
            }

            var negativeCountSpaces = countSpacesPadded * (-1);
            var paddingFormat = string.Format("{{0,{0}}}", negativeCountSpaces);
            Console.WriteLine(paddingFormat, number);
        }

        internal static void PrintNumberPaddedLeft(double number, int countSpacesPadded)
        {
            if (countSpacesPadded < 0)
            {
                throw new ArgumentException("Left padding symbols must be a positive number");
            }

            var paddingFormat = string.Format("{{0,{0}}}", countSpacesPadded);
            Console.WriteLine(paddingFormat, number);
        }

        internal static void PrintNumberAsPercentage(double number)
        {
            var percentageFormat = "{0:p0}";
            Console.WriteLine(percentageFormat, number);
        }

        internal static void PrintNumberAsFloating(double number, int countDigitsAfterDecimalPoint = 2)
        {
            var roundingFormat = string.Format("{{0:f{0}}}", countDigitsAfterDecimalPoint);
            Console.WriteLine(roundingFormat, number);
        }

        internal static bool IsHorizontal(Point2D firstPoint, Point2D secondPoint)
        {
            return firstPoint.X == secondPoint.X;
        }

        internal static bool IsVertical(Point2D firstPoint, Point2D secondPoint)
        {
            return firstPoint.Y == secondPoint.Y;
        }

        internal static double CalcDistance(Point2D firstPoint, Point2D secondPoint)
        {
            double deltaXSquare = (secondPoint.X - firstPoint.X) * (secondPoint.X - firstPoint.X);
            double deltaYSquare = (secondPoint.Y - firstPoint.Y) * (secondPoint.Y - firstPoint.Y);

            double distanceSq = deltaXSquare + deltaYSquare;
            double distance = Math.Sqrt(distanceSq);

            return distance;
        }

        internal static int CompareAges(string firstStudentInfo, string secondStudentInfo)
        {
            var firstBirthday = HelpMethods.ParseBirthday(firstStudentInfo);
            var secondBirthday = HelpMethods.ParseBirthday(secondStudentInfo);

            if (firstBirthday < secondBirthday)
            {
                return 1;
            }
            else if (firstBirthday > secondBirthday)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private static DateTime ParseBirthday(string info)
        {
            var birthdayText = info.Substring(info.Length - 10);
            var birthday = DateTime.ParseExact(birthdayText, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            return birthday;
        }
    }
}
