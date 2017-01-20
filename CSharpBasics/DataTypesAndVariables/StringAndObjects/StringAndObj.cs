using System;
class StringAndObj
{
    static void Main()
    {
        string firstText = "Hello";
        string secondText = "World";
        object wtf = firstText + " " + secondText;
        string finalText = (string)wtf;
        Console.WriteLine(finalText);
    }
}

