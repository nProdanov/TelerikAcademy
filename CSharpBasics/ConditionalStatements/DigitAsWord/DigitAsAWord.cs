using System;
class DigitAsAWord
{
    static void Main()
    {
        string input = Console.ReadLine();
        sbyte digit;
        if (sbyte.TryParse(input, out digit))
        {
            if (digit >= 0 && digit <= 9)
            {
                switch (digit)
                {
                    case 1: Console.WriteLine("one"); break;
                    case 2: Console.WriteLine("two"); break;
                    case 3: Console.WriteLine("three"); break;
                    case 4: Console.WriteLine("four"); break;
                    case 5: Console.WriteLine("five"); break;
                    case 6: Console.WriteLine("six"); break;
                    case 7: Console.WriteLine("seven"); break;
                    case 8: Console.WriteLine("eight"); break;
                    case 9: Console.WriteLine("nine"); break;
                    default: Console.WriteLine("zero"); break;

                }
            }

            else
            {

                Console.WriteLine("not a digit");
            }
        }
        else
        {
            Console.WriteLine("not a digit");
        }
        


    }
}

