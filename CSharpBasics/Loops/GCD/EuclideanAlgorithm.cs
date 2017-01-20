using System;
class EuclideanAlgorithm
{
    static void Main()
    {
       
        string text =Console.ReadLine();
        string[] numbersAsAStringArray = text.Split(new char[] { ' ', ' ', '!' }, StringSplitOptions.RemoveEmptyEntries);
        int[] numbers = new int[2];
        for (int i = 0; i < 2; i++)
        {
            numbers[i] = int.Parse(numbersAsAStringArray[i]);
        }
        int a = numbers[0];
        a = Math.Abs(a);
        int b = numbers[1];
        b = Math.Abs(b);
        while (a != 0 && b != 0)
        {
            if (a > b)
                a = (a % b);
            else
                b = (b % a);
        }

        if (a == 0)
        {
            Console.WriteLine(b);
        }
        else
        {
            Console.WriteLine(a);
        }
    }
}

