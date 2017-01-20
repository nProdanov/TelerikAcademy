using System;

using SchoolSystem.Contracts;

namespace SchoolSystem.Models
{
    public class ConsoleLoggerProvider : ILogger
    {
        public void Log(string text)
        {
            Console.WriteLine(text);
        }
    }
}
