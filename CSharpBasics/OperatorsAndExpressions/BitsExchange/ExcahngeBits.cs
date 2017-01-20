using System;
class ExcahngeBits
{
    public static bool GetBit(uint number, byte position)
    {
        uint mask = (uint)1 << position;
        mask = number & mask;
        if (mask>0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public static uint ChangeBit(uint number, bool bit, byte position)
    {
        uint mask = 1;
        mask = mask << position;
        if (bit)
        {
            return number | mask;
        }
        else
        {
            return number & ~mask;
        }
    }
    
    static void Main()
    {
        uint number = uint.Parse(Console.ReadLine());
       
        bool tr =  GetBit(number,3);
        bool fo =  GetBit(number,4);
        bool fiv = GetBit(number, 5);
        bool twfo = GetBit(number,24);
        bool twfiv = GetBit(number,25);
        bool twsix = GetBit(number,26);

        number = ChangeBit(number, tr, 24);
        number = ChangeBit(number, fo, 25);
        number = ChangeBit(number, fiv, 26);
        number = ChangeBit(number, twfo, 3);
        number = ChangeBit(number, twfiv, 4);
        number = ChangeBit(number, twsix, 5);

        Console.WriteLine(number);
    }

}

