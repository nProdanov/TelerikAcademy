using Computers.Common.Components.Motherboard;
using Computers.Common.Contracts;

namespace Computers.Common.ComputerSystems
{
    public class ComputerSystem : IComputerSystem
    {
        protected IMotherboard motherboard;
        private ICpu cpu;
        private IRam ram;
        private IVideoCard videoCard;

        public ComputerSystem(ICpu cpu, IRam ram, IVideoCard videoCard, IStorage storage)
        {
            this.cpu = cpu;
            this.ram = ram;
            this.videoCard = videoCard;
            this.HardDrives = storage;
            this.motherboard = new Motherboard(this.cpu, this.videoCard, this.ram);
        }

        public IMotherboard Motherboard { get; set; }

        public IStorage HardDrives { get; set; }
    }
}
