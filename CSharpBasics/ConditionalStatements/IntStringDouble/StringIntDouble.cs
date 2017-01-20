using System;
    class StringIntDouble
    {
        static void Main()
        {
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "integer": 
                    int integerNumber = int.Parse(Console.ReadLine());
                    integerNumber += 1;
                    Console.WriteLine(integerNumber); 
                    break;
                case "real":
                    double realNumber = double.Parse(Console.ReadLine());
                    realNumber += 1;
                    Console.WriteLine("{0:F2}",realNumber); 
                    break;
                default:
                    string text = Console.ReadLine();
                    text += '*';
                    Console.WriteLine(text);
                    break;
            }
        }
    }

