using System;
class BitModify
{
    static void Main()
    {
        ulong number = ulong.Parse(Console.ReadLine());
        byte position = byte.Parse(Console.ReadLine());
        ulong bit = ulong.Parse(Console.ReadLine());
        if (bit > 0)
        {
            bit = bit << position;
            number = number | bit;
            Console.WriteLine(number);
        }
        else
        {
            bit = 1;
            bit = bit << position;
            number = number & ~bit;
            Console.WriteLine(number);
        }
    }
}