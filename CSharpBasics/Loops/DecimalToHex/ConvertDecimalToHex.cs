using System;
class ConvertDecimalToHex
{
    static void Main()
    {
        long decimalNumebr = long.Parse(Console.ReadLine());
        string hex = "";
        while (decimalNumebr >= 1)
        {
            long curent = decimalNumebr % 16;
            if (curent>=0&&curent<=9)
            {
                hex = curent + hex;
                decimalNumebr /= 16;
            }
            else
            {
                switch (curent)
                {
                    case 10: hex = 'A' + hex; break;
                    case 11: hex = 'B' + hex; break;
                    case 12: hex = 'C' + hex; break;
                    case 13: hex = 'D' + hex; break;
                    case 14: hex = 'E' + hex; break;
                    case 15: hex = 'F' + hex; break;
                }
                decimalNumebr /= 16;
            }
        }
        Console.WriteLine(hex);
    }
}

