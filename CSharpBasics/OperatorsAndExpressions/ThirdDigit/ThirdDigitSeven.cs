using System;
class ThirdDigitSeven
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        for (int i = 0; i < 2; i++)
        {
            number /= 10;  
        }
        int result = (int)(number % 10);
        if (result == 7)
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false {0}",result);
        }
    }
}

