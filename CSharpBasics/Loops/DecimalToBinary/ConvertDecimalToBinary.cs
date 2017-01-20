using System;
class ConvertDecimalToBinary
{
    static void Main()
    {
        long decimalNumber = long.Parse(Console.ReadLine());
        string binary = "";
        while(decimalNumber >= 1)
        {
            binary = (decimalNumber % 2)+binary;
            decimalNumber /= 2;
        }
       
        Console.WriteLine(binary);

    }
}
