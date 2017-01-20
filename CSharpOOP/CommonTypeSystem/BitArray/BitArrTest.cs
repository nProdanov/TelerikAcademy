namespace BitArray
{
    using System;

    public class BitArrTest
    {
        public static void Main()
        {
            var first = new BitArray(10);
            var second = new BitArray(11);
            
            Console.WriteLine(string.Format("first - > {0}", first));
            Console.WriteLine(string.Format("second - > {0}", second));
            Console.WriteLine(string.Format("first == second  - > {0}", first == second));
            Console.WriteLine(string.Format("Hash code of first: {0}", first.GetHashCode()));
            Console.WriteLine(string.Format("Hash code of second: {0}", second.GetHashCode()));

            Separator();

            first[0] = 1;
            Console.WriteLine(string.Format("first - > {0}", first));
            Console.WriteLine(string.Format("second - > {0}", second));
            Console.WriteLine(string.Format("first == second  - > {0}", first == second));
            Console.WriteLine(string.Format("Hash code of first: {0}", first.GetHashCode()));
            Console.WriteLine(string.Format("Hash code of second: {0}", second.GetHashCode()));

            Separator();

            Console.WriteLine("Test foreach:");
            foreach (var bit in first)
            {
                Console.Write(string.Format("{0} ", bit));
            }
        }

        private static void Separator()
        {
            Console.WriteLine(new string('-', 25));
        }
    }
}
