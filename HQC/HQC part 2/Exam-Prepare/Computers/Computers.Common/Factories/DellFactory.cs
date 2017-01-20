using System.Collections.Generic;

using Computers.Common.Components.Battery;
using Computers.Common.Components.Cpus;
using Computers.Common.Components.Ram;
using Computers.Common.Components.Storages;
using Computers.Common.Components.VideoCards;
using Computers.Common.ComputerSystems;
using Computers.Common.Contracts;

namespace Computers.Common.Factories
{
    public class DellFactory : IComputerSystemFactory
    {
        public const string Name = "Dell";

        public Laptop CreateLaptop()
        {
            return new Laptop(
                     new Cpu32(4),
                     new Ram(8),
                     new ColourVideoCard(),
                     new HardDrive(1000),
                     new LaptopBattery());
        }

        public Pc CreatePc()
        {
            return new Pc(
                new Cpu64(4),
                new Ram(8),
                new ColourVideoCard(),
                new HardDrive(1000));
        }

        public Server CreateServer()
        {
            return new Server(
                    new Cpu64(8),
                    new Ram(64),
                    new MonochromeVideoCard(),
                    new HardDrivesRaid(4000, new List<IStorage> { new HardDrive(2000), new HardDrive(2000) }));
        }
    }
}
