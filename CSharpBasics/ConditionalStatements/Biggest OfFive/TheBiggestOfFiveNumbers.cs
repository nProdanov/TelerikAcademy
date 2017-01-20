using System;
class TheBiggestOfFiveNumbers
{
    static void Main()
    {
        //double max = double.MinValue;
        //double a = double.Parse(Console.ReadLine());
        //if (a > max)
        //{
        //    max = a;
        //}
        //double b = double.Parse(Console.ReadLine());
        //if (b > max)
        //{
        //    max = b;
        //}
        //double c= double.Parse(Console.ReadLine());
        //if (c > max)
        //{
        //    max = c;
        //}
        //double d = double.Parse(Console.ReadLine());
        //if (d > max)
        //{
        //    max = d;
        //}
        //double e = double.Parse(Console.ReadLine());
        //if (e > max)
        //{
        //    max = e;
        //}
        //Console.WriteLine(max);

        double max = double.MinValue;
        for (int i = 0; i < 5; i++)
        {
            double x = double.Parse(Console.ReadLine());
            if (x > max)
            {
                max = x;
            }
        }
        Console.WriteLine(max);
    }
}

