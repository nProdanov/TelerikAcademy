using System;

namespace Company.DataImporter.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string output)
        {
            Console.Write(output);
        }

        public void LogLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
