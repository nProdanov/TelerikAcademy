using System;
using System.Linq;

using DbFirst.Data;
using DbFirst.DataImporter.Logger;
using DbFirst.DataImporter.RandomGenerator;

namespace DbFirst.DataImporter.Importers
{
    public class GPUImporter : IImporter
    {
        private const int NumberOfGpus= 100;

        public Action<ComputersEntities, ILogger, IRandomGenerator> Get
        {
            get
            {
                return (db, logger, randomGenerator) =>
                {
                    var vendorIds = db.Vendors.Select(v => v.Id).ToList();

                    for (int i = 0; i < NumberOfGpus; i++)
                    {
                        var gpuToAdd = new Gpu()
                        {
                            VendorId = vendorIds[randomGenerator.GetRandomNumber(0, vendorIds.Count - 1)],
                            Model = randomGenerator.GetRandomString(2, 20),
                            Memory = randomGenerator.GetRandomString(1, 10),
                            Type = randomGenerator.GetRandomNumber(0, 1) != 0
                        };
                        db.Gpus.Add(gpuToAdd);
                        logger.Log(".");
                    }

                    db.SaveChanges();
                    logger.LogLine(string.Empty);
                };
            }
        }

        public string Message
        {
            get { return "Importing gpus"; }
        }

        public int Order
        {
            get { return 3; }
        }
    }
}
