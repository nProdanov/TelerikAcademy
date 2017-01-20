using Computers.Common.Contracts;

namespace Computers.Common.ComputerSystems
{
    public class Laptop : ComputerSystem
    {
        private const string BatteryStatusMessageFormat = "Battery status: {0}%";

        private ILaptopBattery battery;

        public Laptop(ICpu cpu, IRam ram, IVideoCard videoCard, IStorage storage, ILaptopBattery battery) 
            : base(cpu, ram, videoCard, storage)
        {
            this.battery = battery;
        }

        public void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);

            this.motherboard.DrawOnVideoCard(string.Format(BatteryStatusMessageFormat, this.battery.Percentage));
        }
    }
}
