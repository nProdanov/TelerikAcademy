using System;
class NullableValues
{
    static void Main()
    {
        int? a = null;
        double? b = null;
        Console.WriteLine(a);
        Console.WriteLine(b);
        a += 5;
        b += null;
        Console.WriteLine(a);
        Console.WriteLine(b);
    
    
    }
}

