using System;

using Messages.Utils;

namespace Messages
{
    internal class StartPoint
    {
        internal static void Main(string[] args)
        {
            var parameters = Reader.ReadParameters();

            var message = new Message(parameters);

            Console.WriteLine(message.TranslatedMessage);
        }
    }
}
