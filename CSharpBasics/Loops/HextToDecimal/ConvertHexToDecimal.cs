using System;
class ConvertHexToDecimal
{
    static void Main()
    {
        string hex = Console.ReadLine();
        long decimalNumber = 0;
        long pow = 1;
        for (int i = hex.Length-1; i >= 0; i--)
        {
            if (hex[i]-'0'>=0&&hex[i]-'0'<=9)
            {
                int current = hex[i] - '0';
                decimalNumber += (current * pow);
                pow *= 16;
            }
            else
            {
                int current=0;
                switch (hex[i])
                {
                    case 'A': current = 10; break;
                    case 'B': current = 11; break;
                    case 'C': current = 12; break;
                    case 'D': current = 13; break;
                    case 'E': current = 14; break;

                    default: current = 15;
                        break;
                }
                decimalNumber += (current * pow);
                pow *= 16;
            }
            
        }
        Console.WriteLine(decimalNumber);
    }
}

