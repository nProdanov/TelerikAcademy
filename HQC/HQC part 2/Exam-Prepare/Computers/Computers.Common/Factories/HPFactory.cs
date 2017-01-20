using System.Collections.Generic;

using Computers.Common.Components.Battery;
using Computers.Common.Components.Cpus;
using Computers.Common.Components.Ram;
using Computers.Common.Components.Storages;
using Computers.Common.Components.VideoCards;
using Computers.Common.ComputerSystems;

namespace Computers.Common.Contracts.Factories
{
    public class HPFactory : IComputerSystemFactory
    {
        public const string Name = "HP";

        public Laptop CreateLaptop()
        {
            return new Laptop(
                    new Cpu64(2),
                    new Ram(16),
                    new ColourVideoCard(),
                    new HardDrive(500),
                    new LaptopBattery());
        }

        public Pc CreatePc()
        {
            return new Pc(
                    new Cpu32(2),
                    new Ram(2),
                    new ColourVideoCard(),
                    new HardDrive(500));
        }

        public Server CreateServer()
        {
            return new Server(
                    new Cpu32(4),
                    new Ram(32),
                    new MonochromeVideoCard(),
                    new HardDrivesRaid(2000, new List<IStorage> { new HardDrive(1000), new HardDrive(1000) }));
        }
    }
}
