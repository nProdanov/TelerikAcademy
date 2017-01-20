using System;

namespace Dealership.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string output)
        {
            Console.WriteLine(output);
        }
    }
}
