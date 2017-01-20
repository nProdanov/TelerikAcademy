using Computers.Common.Contracts;

namespace Computers.Common.Components.Battery
{
    internal class LaptopBattery : ILaptopBattery
    {
        internal LaptopBattery()
        {
            this.Percentage = 50;
        }

        public int Percentage { get; set; }

        public void Charge(int deltaPercentage)
        {
            this.Percentage += deltaPercentage;
            if (this.Percentage > 100)
            {
                this.Percentage = 100;
            }

            if (this.Percentage < 0)
            {
                this.Percentage = 0;
            }
        }
    }
}
