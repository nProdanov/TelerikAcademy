using System;
class QuadrEquation
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        double d = b * b - 4 * a * c;
        if (d<0)
        {
            Console.WriteLine("no real roots");
        }
        else if (d == 0)
        {
            double k = -(b) / (2 * a);
            Console.WriteLine("{0:F2}",k);

        }
        else
        {
            double xOne = (-(b) + Math.Sqrt(d)) / (2 * a);
            double xTwo = (-(b) - Math.Sqrt(d)) / (2 * a);
            if (xOne < xTwo)
            {
                Console.WriteLine("{0:F2}", xOne);
                Console.WriteLine("{0:F2", xTwo);
            }
            else 
            {
                Console.WriteLine("{0:F2}", xTwo);
                Console.WriteLine("{0:F2}", xOne);

            }
        }
    }
}

