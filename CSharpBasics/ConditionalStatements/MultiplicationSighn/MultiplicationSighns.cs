using System;
class MultiplicationSighns
{
    static void Main()
    {
        int countMinus = 0;
        bool isThereZero = false;
        double a = double.Parse(Console.ReadLine());
        if (a<0)
        {
            countMinus++;
        }
        else if (a==0)
        {
            isThereZero = true; 
        }
        double b = double.Parse(Console.ReadLine());
        if (b< 0)
        {
            countMinus++;
        }
        else if (b == 0)
        {
            isThereZero = true;
        }
        double c = double.Parse(Console.ReadLine());
        if (c < 0)
        {
            countMinus++;
        }
        else if (c == 0)
        {
            isThereZero = true;
        }
        if (isThereZero)
        {
            Console.WriteLine(0);
        }
        else if(countMinus%2!=0)
        {
            Console.WriteLine("-");
        }
        else
        {
            Console.WriteLine("+");
        }
    }
}

