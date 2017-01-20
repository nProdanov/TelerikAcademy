using System;
using System.Linq;

using DbFirst.Data;
using DbFirst.DataImporter.Logger;
using DbFirst.DataImporter.RandomGenerator;

namespace DbFirst.DataImporter.Importers
{
    public class StorageDeviceImporter : IImporter
    {
        private const int NumberOfStorageDevices = 50;

        public Action<ComputersEntities, ILogger, IRandomGenerator> Get
        {
            get
            {
                return (db, logger, randomGenerator) =>
                {
                    var vendorIds = db.Vendors.Select(v => v.Id).ToList();

                    for (int i = 0; i < NumberOfStorageDevices; i++)
                    {
                        var storageDeviceToAdd = new StorageDevice()
                        {
                            Model = randomGenerator.GetRandomString(2, 20),
                            Size = randomGenerator.GetRandomString(1, 10),
                            Type = randomGenerator.GetRandomNumber(0, 1) != 0,
                            VendorId = vendorIds[randomGenerator.GetRandomNumber(0, vendorIds.Count - 1)]
                        };

                        db.StorageDevices.Add(storageDeviceToAdd);
                        logger.Log(".");
                    }

                    db.SaveChanges();
                    logger.LogLine(string.Empty);
                };
            }
        }

        public string Message
        {
            get { return "Imporitng Storage devices"; }
        }

        public int Order
        {
            get { return 4; }
        }
    }
}
