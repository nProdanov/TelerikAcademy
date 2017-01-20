using System;

namespace LinkedList
{
    public class Startup
    {
        public static void Main()
        {
            var myLinkedList = new MyLinkedList<int>();

            myLinkedList.AddFirst(4);
            myLinkedList.AddFirst(10);
            myLinkedList.AddLast(5);
            myLinkedList.AddFirst(2);

            foreach (var item in myLinkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
