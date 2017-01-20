using System;

namespace Messages.Utils
{
    internal static class Reader
    {
        internal static string[] ReadParameters()
        {
            var parameters = new string[3];

            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = Console.ReadLine();
            }

            return parameters;
        }
    }
}
