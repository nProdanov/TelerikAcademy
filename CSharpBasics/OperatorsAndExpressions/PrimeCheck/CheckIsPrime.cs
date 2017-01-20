using System;
class CheckIsPrime
{
    static void Main()
    {
        sbyte number = sbyte.Parse(Console.ReadLine());
        bool isPrime = true;
        if (number <= 1)
        {
            Console.WriteLine("false");
            isPrime = false;
        }
        else if (number == 2)
        {
            Console.WriteLine("true");
            isPrime = false;
        }
        byte devider = 2;
        while (devider<=Math.Sqrt(number)&&isPrime)
        {
            if (number%devider==0)
            {
                Console.WriteLine("false");
                isPrime = false;
                break;
            }
            devider++;
            
        }
        if (isPrime)
        {
            Console.WriteLine("true");
        }
    }
}

