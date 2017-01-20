using System;
class ThirdBitValue
{
    static void Main()
    {
        uint number = uint.Parse(Console.ReadLine());
        uint mask = 1;
        mask = mask << 3;
        number = number & mask;
        number = number >> 3;
        Console.WriteLine(number);
    }
}

