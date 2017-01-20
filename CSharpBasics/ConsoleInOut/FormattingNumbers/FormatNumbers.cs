using System;
class FormatNumbers
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        string a = number.ToString("X");
        string aBinary= Convert.ToString(number,2).PadLeft(10,'0');
        Console.WriteLine("{0,-10} {1} {2:F2,10} {3:F3,-10}", a,aBinary,b,c);

    }
}

