using System;
class NthBith
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        long mask = 1;
        byte n = byte.Parse(Console.ReadLine());
        mask = mask << n;
        number = number & mask;
        number = number >> n;
        Console.WriteLine(number);
    }
}

