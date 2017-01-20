using System;
using System.Numerics;
using System.Text;
class AddingNumbersAsArray
{
    static BigInteger ToBigInt(string a)
    {
        
        StringBuilder reversed = new StringBuilder();
        for (int i = a.Length-1; i >=0; i--)
        {
            reversed.Append(a[i]);
            
        }
        return BigInteger.Parse(reversed.ToString());
    }
    static BigInteger Sum(string first, string second)
    {
        BigInteger a = ToBigInt(first);
        BigInteger b = ToBigInt(second);
        return a + b;
    }
    static void Main()
    {
        string firstNumber = Console.ReadLine();
        string secondNumber = Console.ReadLine();
        Console.WriteLine(Sum(firstNumber,secondNumber));
    }
}

