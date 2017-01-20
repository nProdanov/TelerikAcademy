using System;
using System.Collections.Generic;

namespace Reverse_Polish_Notation
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var inputArray = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var numbers = new Stack<int>();

            foreach (var current in inputArray)
            {
                if (current == "-" || current == "+" ||
                    current == "*" || current == "/" ||
                    current == "&" || current == "|" ||
                    current == "^")
                {
                    var secondNumber = numbers.Pop();
                    var firstNumber = numbers.Pop();
                    if (current == "+")
                    {
                        numbers.Push((firstNumber + secondNumber));
                    }
                    else if (current == "-")
                    {
                        numbers.Push((firstNumber - secondNumber));
                    }
                    else if (current == "*")
                    {
                        numbers.Push((firstNumber * secondNumber));
                    }
                    else if (current == "/")
                    {
                        numbers.Push((firstNumber / secondNumber));
                    }
                    else if (current == "&")
                    {
                        numbers.Push((firstNumber & secondNumber));
                    }
                    else if (current == "|")
                    {
                        numbers.Push((firstNumber | secondNumber));
                    }
                    else
                    {
                        numbers.Push((firstNumber ^ secondNumber));
                    }
                }
                else
                {
                    numbers.Push(int.Parse(current));
                }
            }

            Console.WriteLine(numbers.Pop());
        }
    }
}
