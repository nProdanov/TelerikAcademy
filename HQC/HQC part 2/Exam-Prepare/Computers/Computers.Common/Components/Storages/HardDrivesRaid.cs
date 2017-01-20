using System;
using System.Collections.Generic;
using System.Linq;

using Computers.Common.Contracts;

namespace Computers.Common.Components.Storages
{
    public class HardDrivesRaid : Storage
    {
        private IEnumerable<IStorage> hardDrives;

        public HardDrivesRaid(int capacity, IEnumerable<IStorage> hardDrives)
            : base(capacity)
        {
            this.hardDrives = hardDrives;
        }

        public override int Capacity
        {
            get
            {
                if (!this.hardDrives.Any())
                {
                    return 0;
                }
                else
                {
                    return this.hardDrives.First().Capacity;
                }
            }
        }

        public override string LoadData(int address)
        {
            if (!this.hardDrives.Any())
            {
                throw new OutOfMemoryException("No hard drive in the RAID array!");
            }
            else
            {
                return this.hardDrives.First().LoadData(address);
            }
        }

        public override void SaveData(int address, string newData)
        {
            foreach (var hardDrive in this.hardDrives)
            {
                hardDrive.SaveData(address, newData);
            }
        }
    }
}
