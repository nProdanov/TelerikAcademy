namespace Computers.Common.Components.Storages
{
    public class HardDrive : Storage
    {
        public HardDrive(int capacity) 
            : base(capacity)
        {
        }

        public override int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public override string LoadData(int address)
        {
            return this.data[address];
        }

        public override void SaveData(int address, string newData)
        {
            this.data[address] = newData;
        }
    }
}
