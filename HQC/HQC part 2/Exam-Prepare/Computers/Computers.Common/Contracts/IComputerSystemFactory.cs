using Computers.Common.ComputerSystems;

namespace Computers.Common.Contracts
{
    public interface IComputerSystemFactory
    {
        Pc CreatePc();

        Laptop CreateLaptop();

        Server CreateServer();
    }
}
