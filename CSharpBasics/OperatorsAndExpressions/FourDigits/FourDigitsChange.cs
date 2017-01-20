using System;
class FourDigitsChange
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        byte d = (byte)(number % 10);
        number /= 10;
        byte c = (byte)(number % 10);
        number /= 10;
        byte b = (byte)(number % 10);
        number /= 10;
        Console.WriteLine(d+b+c+number);
        Console.WriteLine("{0}{1}{2}{3}",d,c,b,number);
        Console.WriteLine("{0}{1}{2}{3}", d,number,b,c);
        Console.WriteLine("{0}{1}{2}{3}", number,c,b,d);
        
    }
}

