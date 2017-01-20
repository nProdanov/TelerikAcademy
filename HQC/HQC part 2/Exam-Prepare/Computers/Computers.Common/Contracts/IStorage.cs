namespace Computers.Common.Contracts
{
    public interface IStorage
    {
        int Capacity { get; }

        string LoadData(int address);

        void SaveData(int address, string newData);
    }
}