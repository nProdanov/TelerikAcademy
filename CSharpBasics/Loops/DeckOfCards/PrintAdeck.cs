using System;
class PrintAdeck
{
    static void PrintSign(string choice, string sign)
    {
        Console.Write("{0} {1}",choice, sign);
    }

    static void Main()
    {
        //uslovieto!!

        string choice = Console.ReadLine();
        choice = choice.ToUpper();
        string[] signs = {"of spades","of clubs","of hearts","of diamonds"};
        string[] choices = {"2","3","4","5","6","7","8","9","10","J","Q","K","A"};
        int position = Array.IndexOf(choices,choice);
        for (int i = 0; i <= position; i++)
        {
            for (int j = 0; j < signs.Length; j++)
            {
                PrintSign(choices[i],signs[j]);
                if (i==position&&j==signs.Length-1)
                {
                    break;
                }
                Console.Write(", ");
            }
            Console.WriteLine();
        }
       


    }
}

