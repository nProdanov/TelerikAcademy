using System;
class InCircle
{
    static void Main()
    {
        double xO = double.Parse(Console.ReadLine());
        double yO = double.Parse(Console.ReadLine());
        int r = 2;
        double distance = Math.Sqrt(xO * xO + yO * yO); 
        if (xO * xO + yO * yO <= r * r)
        {
            Console.WriteLine("yes {0:F2}",distance);
        }
        else
        {
            Console.WriteLine("no {0:F2}",distance);
        }
    }
}

