using System;
using System.Text;
class Triangle
{
    static void Main()
    {
        UTF8Encoding utf8 = new UTF8Encoding();
        char copyright = '©';
        Console.Write(new string (' ', 5));
        Console.WriteLine(copyright);
        int spaceCounter = 1;
        for (int i = 4; i >= 1; i--)
        {
            Console.Write(new string(' ', i));
            Console.Write(copyright);
            Console.Write(new string(' ',spaceCounter));
            Console.WriteLine(copyright);
            spaceCounter+=2;
        }
        Console.WriteLine(new string(copyright,spaceCounter+2));
    }
}

