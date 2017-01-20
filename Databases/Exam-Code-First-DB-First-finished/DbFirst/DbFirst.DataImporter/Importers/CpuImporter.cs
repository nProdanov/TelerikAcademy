using System;
using System.Linq;
using DbFirst.Data;
using DbFirst.DataImporter.Logger;
using DbFirst.DataImporter.RandomGenerator;

namespace DbFirst.DataImporter.Importers
{
    class CpuImporter : IImporter
    {
        public const int NumberOfCpus = 20;
        public Action<ComputersEntities, ILogger, IRandomGenerator> Get
        {
            get
            {
                return (db, logger, randomGenerator) =>
                {
                    var vendorIds = db.Vendors.Select(v => v.Id).ToList();

                    for (int i = 0; i < NumberOfCpus; i++)
                    {
                        db.Cpus.Add(new Cpu()
                        {
                            Model = randomGenerator.GetRandomString(2, 20),
                            ClockCyclyes = randomGenerator.GetRandomString(1, 5),
                            NumberOfCores = randomGenerator.GetRandomNumber(1, 5),
                            VendorId = vendorIds[randomGenerator.GetRandomNumber(0, vendorIds.Count - 1)]
                        });
                        logger.Log(".");
                    }

                    db.SaveChanges();
                    logger.LogLine(string.Empty);
                };
            }
        }

        public string Message
        {
            get { return "Importing Cpus"; }
        }

        public int Order
        {
            get { return 2; }
        }
    }
}
