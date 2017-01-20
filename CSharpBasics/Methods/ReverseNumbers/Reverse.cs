using System;
using System.Text;
class Reverse
{
    static string ReverseNumber(string number)
    {
        StringBuilder reversed = new StringBuilder();
        for (int i = number.Length-1; i >=0; i--)
        {
            reversed.Append(number[i]);

        }
        return reversed.ToString();
    }
    static void Main()
    {
        string number = Console.ReadLine();
        Console.WriteLine(ReverseNumber(number));
    }
}

