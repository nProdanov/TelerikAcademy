using System;
class CompareNumbers
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double r = (Math.Sqrt(a * a + b * b - 2 * a * b) + a + b) / 2;
        Console.WriteLine(r);

    }
}

