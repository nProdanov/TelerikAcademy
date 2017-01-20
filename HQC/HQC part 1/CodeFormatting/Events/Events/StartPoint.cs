namespace Events
{
    using System;

    public static class StartPoint
    {
        public static void Main(string[] args)
        {
            while (EventsEngine.ExecuteNextCommand())
            {
            }

            Console.WriteLine(Messages.Output);
        }
    }
}
