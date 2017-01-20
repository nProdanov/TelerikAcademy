namespace Birds
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double birdsCount = int.Parse(Console.ReadLine());
            long feathersCount = long.Parse(Console.ReadLine());

            double averageFeathersOnBird = birdsCount != 0 ? feathersCount / birdsCount : 0;

            double result = 0;
            if (birdsCount % 2 == 0)
            {
                result = MultiplicateAverageFeathers(averageFeathersOnBird);

            }
            else
            {
                result = DevideAverageFeathers(averageFeathersOnBird);
            }

            Console.WriteLine(string.Format("{0:F4}", result));
        }

        public static double MultiplicateAverageFeathers(double averageFeathersOnBird)
        {
            double specialMultiplier = 123123123123;
            double multiplication = averageFeathersOnBird * specialMultiplier;

            return multiplication;
        }

        public static double DevideAverageFeathers(double averageFeathersOnBird)
        {
            double specialDevider = 317;
            double division = averageFeathersOnBird / specialDevider;

            return division;
        }
    }
}