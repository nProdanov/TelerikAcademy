namespace Buses
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfBuses = int.Parse(Console.ReadLine());

            int speedGroups = FindSpeedGroups(numberOfBuses);
            Console.WriteLine(speedGroups);
        }

        public static int FindSpeedGroups(int numberOfBuses)
        {
            int speedOftheFirstBus = int.Parse(Console.ReadLine());
            int speedOfGroup = speedOftheFirstBus;

            int groups = 1;

            for (int i = 1; i < numberOfBuses; i++)
            {
                int speedOfNextBus = int.Parse(Console.ReadLine());

                if (speedOfNextBus <= speedOfGroup)
                {
                    groups++;
                    speedOfGroup = speedOfNextBus;
                }
            }

            return groups;
        }
    }
}
