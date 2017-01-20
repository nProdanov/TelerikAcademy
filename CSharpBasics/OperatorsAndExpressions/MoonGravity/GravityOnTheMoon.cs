using System;
class GravityOnTheMoon
{
    static void Main()
    {
        double weight = double.Parse(Console.ReadLine());
        
        double weightOnMoon = weight * 17 / 100;
        Console.WriteLine("{0:F3}",weightOnMoon);
    }
}

