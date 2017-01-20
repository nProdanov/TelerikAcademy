namespace Computers.Common.Contracts
{
    public interface IComputerSystem
    {
        IStorage HardDrives { get; set; }

        IMotherboard Motherboard { get; set; }
    }
}