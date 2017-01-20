using System;
class Calculating
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double x = double.Parse(Console.ReadLine());
        double sum = 1;
        long factoriel = 1;
        double sup = 1;
        for (int i = 1; i <=n; i++)
        {
            factoriel *= i;
            sup *= x;
            sum += (factoriel / sup);
          
        }
        Console.WriteLine("{0:F5}",sum);

    }
}

