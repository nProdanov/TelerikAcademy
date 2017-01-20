using System;
class CompareDoubles
{
    static void Main()
    {
        double first = double.Parse(Console.ReadLine());
        double second = double.Parse(Console.ReadLine());
        double eps = 0.000001;
        

        if (first - second > 0)
        {
            if (first-second>=eps)
            {
                Console.WriteLine("false");
            }
            else
            {
                
                Console.WriteLine("true");
            }
        }
        else if (first - second < 0)
        {
            if (second - first >= eps)
            {
                Console.WriteLine("false");
            }
            else
            {
               
                Console.WriteLine("true");
            }
        }
        else
        {
            Console.WriteLine("true");
        }
    }
}

