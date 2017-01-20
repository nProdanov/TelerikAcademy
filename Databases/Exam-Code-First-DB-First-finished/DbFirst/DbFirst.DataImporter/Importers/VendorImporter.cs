using System;
using DbFirst.DataImporter.Logger;
using DbFirst.DataImporter.RandomGenerator;
using DbFirst.Data;

namespace DbFirst.DataImporter.Importers
{
    public class VendorImporter : IImporter
    {
        private const int NumberOfVendors = 20;
        public Action<ComputersEntities, ILogger, IRandomGenerator> Get
        {
            get
            {
                return (db, logger, randormGenerator) =>
                {
                    for (int i = 0; i < NumberOfVendors; i++)
                    {
                        db.Vendors.Add(new Vendor() { Name = randormGenerator.GetRandomString(2, 20)});
                        logger.Log(".");
                    }

                    db.SaveChanges();
                    logger.LogLine(string.Empty);
                };
            }
        }

        public string Message
        {
            get { return "Importing Vendors"; }
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
