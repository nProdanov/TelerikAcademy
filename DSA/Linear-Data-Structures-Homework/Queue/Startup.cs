using System;

namespace Queue
{
    public class Startup
    {
        public static void Main()
        {
            var myQueue = new MyQueue<int>();
            myQueue.Enque(2);
            myQueue.Enque(10);
            myQueue.Enque(12);
            myQueue.Enque(10);
            myQueue.Enque(15);
            myQueue.Enque(13);
            
            while (myQueue.Count != 0)
            {
                Console.WriteLine(myQueue.Dequeue());
            }

        }
    }
}
