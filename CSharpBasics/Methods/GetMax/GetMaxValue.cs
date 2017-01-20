using System;
    class GetMaxValue
    {
        static int GetMax(int first, int second)
        {
            if(first>second)
            {
                return first;
            }
            else
	        {
                return second;
	        }
             
        }

        static void Main()
        {
            Console.Write("enter first integer: ");
            int first = int.Parse(Console.ReadLine());
            Console.Write("enter second integer: ");
            int second = int.Parse(Console.ReadLine());
            Console.Write("enter third integer: ");
            int third = int.Parse(Console.ReadLine());
            int max = GetMax(GetMax(first, second), third);
            Console.WriteLine(max);
        }
    }

