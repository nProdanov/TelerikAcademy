using System;
class DevideWithoutRemainderByfiveAndSeven
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        if (number % 35 == 0)
        {
            Console.WriteLine("true {0}",number);
        }
        else
        {
            Console.WriteLine("false {0}",number);
        }
    }
}

