using System;
class ExchangeTwoNumbers
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        if (a>b)
        {
            a += b;
            b = a - b;
            a = a - b;
        }
        Console.WriteLine("{0} {1}",a,b);
    }
}

