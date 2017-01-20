using System;

namespace Stack
{
    public class Startup
    {
        public static void Main()
        {
            var myStack = new MyStack<int>();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            
            while (myStack.Count != 0)
            {
                Console.WriteLine(myStack.Pop());
            }
        }
    }
}
