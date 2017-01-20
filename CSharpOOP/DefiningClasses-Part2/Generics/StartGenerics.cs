namespace Generics
{
    using System;

    public class StartGenerics
    {
        public static void Separator()
        {
            Console.WriteLine(new string('-', 25));
        }

        public static void Main()
        {
            var myList = new GenericList<string>();

            // Test Add and ToString
            for (int i = 0; i < 16; i++)
            {
                myList.Add(string.Format("{0}", i + 1));
            }

            Console.WriteLine(myList);
            Separator();

            // Test indexer
            Console.WriteLine(myList[4]);
            Separator();

            // Test list Count
            Console.WriteLine(myList.Count);
            Separator();

            // Test Insert and AutoGrow
            myList.Insert("999", 2);
            Console.WriteLine(myList);
            Separator();

            // Test Remove at index
            myList.RemoveAt(2);
            Console.WriteLine(myList);
            Separator();

            // Test Min and Max
            Console.WriteLine("Min element is: {0}", myList.Min());
            Console.WriteLine("Max element is {0}", myList.Max());
            Separator();

            // Test find element by value
            Console.WriteLine(myList.IndexOf("5"));
            Separator();

            // Test Clear
            myList.Clear();
            Console.WriteLine(myList);
            Console.WriteLine(myList.Count);
        }
    }
}
