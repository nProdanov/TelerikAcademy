using Computers.Common.Contracts;

namespace Computers.Common.ComputerSystems
{
    public class Server : ComputerSystem
    {
        public Server(ICpu cpu, IRam ram, IVideoCard videoCard, IStorage storage) 
            : base(cpu, ram, videoCard, storage)
        {
        }

        public void Process(int data)
        {
            this.motherboard.SaveRamValue(data);
            this.motherboard.SquareNumber();
        }
    }
}
