using System.Collections.Generic;

using Computers.Common.Contracts;

namespace Computers.Common.Components.Storages
{
    public abstract class Storage : IStorage
    {
        protected int capacity;
        protected Dictionary<int, string> data;

        public Storage(int capacity)
        {
            this.capacity = capacity;
        }

        public abstract int Capacity { get; }

        public abstract void SaveData(int address, string newData);

        public abstract string LoadData(int address);
    }
}
