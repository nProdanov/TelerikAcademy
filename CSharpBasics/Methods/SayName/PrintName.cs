using System;
class PrintName
{
    static void SayName()
    {
        Console.WriteLine("Enter your name: ");
        Console.WriteLine("Hello, {0}",Console.ReadLine());
    }

    static void Main()
    {
        SayName();
    }
}

