using System;

using Computers.Common.Contracts;

namespace Computers.Common.Components.Cpus
{
    public abstract class Cpu : ICpu
    {
        public static readonly Random Random = new Random();

        protected const string DataNumberTooLow = "Number too low.";
        protected const string DataNumberTooHigh = "Number too high.";
        protected const string ReturnedSquareFormat = "Square of {0} is {1}.";

        protected byte numberOfBits;
        protected int maxCpuPowerNumber;

        internal Cpu(byte numberOfCores)
        {
            this.NumberOfCores = numberOfCores;
        }

        internal byte NumberOfCores { get; set; }

        public string SquareNumber(int number)
        {
            if (number < 0)
            {
                return Cpu.DataNumberTooLow;
            }
            else if (number > this.maxCpuPowerNumber)
            {
                return Cpu.DataNumberTooHigh;
            }
            else
            {
                var squareNumber = number * number;

                return string.Format(Cpu.ReturnedSquareFormat, number, squareNumber);
            }
        }
        
        public int GetRandoNumber(int minNumber, int maxNumber)
        {
            return Random.Next(minNumber, maxNumber + 1);
        }
    }
}
