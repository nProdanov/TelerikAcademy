using System;
class RemainderByFiveIsZero
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        
        int count = 0;
        for (int i = n+1; i <= m-1; i++)
        {
            if (i%5==0)
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }
}

