using System;

using SchoolSystem.Contracts;

namespace SchoolSystem.Models.SchoolActors
{
    public class ConsoleReaderProvider : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
