using System;
class ConvertBinaryToDecimal
{
    static void Main()
    {
        string binary = Console.ReadLine();
        long decimalNumber =0;
        long pow = 1;
        for (int i = binary.Length-1; i >= 0; i--)
        {
            long current = binary[i]-'0';
            decimalNumber += current*pow ;
            pow *= 2;
        }
        Console.WriteLine(decimalNumber);

    }
}

