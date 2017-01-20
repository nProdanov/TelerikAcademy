using System;
class OddAndEvenProduct
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        long productOdd = 1;
        long productEven = 1;
        string[] numbersAsAStringArray = text.Split(new char[] {' ',' ','!'},StringSplitOptions.RemoveEmptyEntries);
        int[] numbers = new int[n];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(numbersAsAStringArray[i]);
            if (i%2==0)
            {
                productOdd *= numbers[i];
            }
            else
            {
                productEven *= numbers[i];
            }
        }
        if (productEven==productOdd)
        {
            Console.WriteLine("yes {0}", productOdd);
        }
        else
        {
            Console.WriteLine("no {0} {1}",productOdd,productEven);
        }
    }
}

