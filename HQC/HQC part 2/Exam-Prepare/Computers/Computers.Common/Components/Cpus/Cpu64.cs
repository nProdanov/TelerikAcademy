namespace Computers.Common.Components.Cpus
{
    public class Cpu64 : Cpu
    {
        private const int NumberOfBits = 64;
        private const int MaxCpuPowerNumber = 1000;

        public Cpu64(byte numberOfCores)
            : base(numberOfCores)
        {
            this.numberOfBits = NumberOfBits;
            this.maxCpuPowerNumber = MaxCpuPowerNumber;
        }
    }
}
