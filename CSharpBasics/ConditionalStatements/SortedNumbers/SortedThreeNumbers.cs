using System;
class SortedThreeNumbers
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        if (a>b&&a>c)
        {
            if (c>b)
            {
                b += c;
                c = b-c;
                b = b - c;
            }
        }
        else if (b > a && b > c)
        {
            a += b;
            b = a - b;
            a = a - b;
            if (c > b)
            {
                b += c;
                c = b - c;
                b = b - c;
            }
        }
        else
        {
            a += c;
            c = a - c;
            a = a - c;
            if (c > b)
            {
                b += c;
                c = b - c;
                b = b - c;
            }

        }
        Console.WriteLine("{0} {1} {2}",a,b,c);
    }
}

