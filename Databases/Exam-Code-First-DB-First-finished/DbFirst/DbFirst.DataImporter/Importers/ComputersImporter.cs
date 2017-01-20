using System;
using System.Linq;

using DbFirst.Data;
using DbFirst.DataImporter.Logger;
using DbFirst.DataImporter.RandomGenerator;

namespace DbFirst.DataImporter.Importers
{
    public class ComputersImporter : IImporter
    {
        private const int NumberOfComputers = 50;

        private const int MaxNumberOfStorageDevicesPerComputer = 5;
        private const int MaxNumberOfGpusNumberPerComputer = 3;

        public Action<ComputersEntities, ILogger, IRandomGenerator> Get
        {
            get
            {
                return (db, logger, randomGenerator) =>
                {
                    var vendorIds = db.Vendors.Select(v => v.Id).ToList();
                    var cpuIds = db.Cpus.Select(c => c.Id).ToList();
                    var storageDevices = db.StorageDevices.ToList();
                    var gpus = db.Gpus.ToList();

                    for (int i = 0; i < NumberOfComputers; i++)
                    {
                        var computerToAdd = new Computer()
                        {
                            CpuId = cpuIds[randomGenerator.GetRandomNumber(0, cpuIds.Count - 1)],
                            Memory = randomGenerator.GetRandomString(2, 10),
                            Type = randomGenerator.GetRandomNumber(0, 2),
                            VendorId = vendorIds[randomGenerator.GetRandomNumber(0, vendorIds.Count - 1)],
                            Model = randomGenerator.GetRandomString(2, 20)
                        };

                        var numberOfStorageDevices = randomGenerator.GetRandomNumber(1, MaxNumberOfStorageDevicesPerComputer);
                        for (int j = 0; j < numberOfStorageDevices; j++)
                        {
                            computerToAdd.StorageDevices.Add(storageDevices[randomGenerator.GetRandomNumber(0, storageDevices.Count - 1)]);
                        }

                        var numberOfGpus = randomGenerator.GetRandomNumber(1, MaxNumberOfGpusNumberPerComputer);
                        for (int j = 0; j < numberOfGpus; j++)
                        {
                            computerToAdd.Gpus.Add(gpus[randomGenerator.GetRandomNumber(0, gpus.Count - 1)]);
                        }

                        db.Computers.Add(computerToAdd);
                        logger.Log(".");
                    }

                    db.SaveChanges();
                    logger.LogLine(string.Empty);
                };
            }
        }

        public string Message
        {
            get { return "Importing computers"; }
        }

        public int Order
        {
            get { return 5; }
        }
    }
}
