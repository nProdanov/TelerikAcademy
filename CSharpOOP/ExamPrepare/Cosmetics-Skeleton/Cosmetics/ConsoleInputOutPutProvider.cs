using System;
using Cosmetics.Contracts;

namespace Cosmetics
{
    public class ConsoleInputOutPutProvider : IInputOutputProvider
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
