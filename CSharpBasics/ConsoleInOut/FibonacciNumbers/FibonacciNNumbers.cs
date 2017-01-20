using System;
class FibonacciNNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        long first = 0;
        long second = 1;
        long third = first + second;
        int count = 3;
        if (n == 1)
        {
            Console.WriteLine(first);
        }
        else if(n==2)
        {
            Console.WriteLine("{0}, {1}",first,second);
        }
        else
        {
            Console.Write("{0}, {1}, ", first, second);
            while (count <= n)
            {
                if (count == n)
                {
                    Console.Write("{0}", third);
                }
                else
                {
                    Console.Write("{0}, ", third);

                }
                first = second;
                second = third;
                third = first + second;
                count++;
            }
        }

    }
}
//using System;
//class FibonacciNNumbers
//{
//    static void Main()
//    {
//        int n = int.Parse(Console.ReadLine());

//        int[] fibonacci = new int[50];
//        fibonacci[0] = 0;
//        fibonacci[1] = 1;

//        if (n==1)
//        {
//            Console.WriteLine(fibonacci[0]);
//        }
//        else if (n == 2)
//        {
//            Console.WriteLine("{0}, {1}",fibonacci[0],fibonacci[1]);
//        }
//        else
//        {
//            Console.Write("{0}, {1}, ", fibonacci[0], fibonacci[1]);
//            for (int i = 2; i < n; i++)
//            {
//                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
//                if (i + 1 == n)
//                {
//                    Console.Write("{0}", fibonacci[i]);
                    
//                }
//                else
//                {
//                    Console.Write("{0}, ", fibonacci[i]);

//                }
//            }
//        }
      


//    }
//}



