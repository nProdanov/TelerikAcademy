namespace Computers.Common.Components.Cpus
{
    public class Cpu32 : Cpu
    {
        private const int NumberOfBits = 32;
        private const int MaxCpuPowerNumber = 500;

        public Cpu32(byte numberOfCores)
            : base(numberOfCores)
        {
            this.numberOfBits = NumberOfBits;
            this.maxCpuPowerNumber = MaxCpuPowerNumber;
        }
    }
}
