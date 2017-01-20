using System;

using Company.Data;
using Company.DataImporter.Logger;

namespace Company.DataImporter.Importers
{
    public class DepartmentsImporter : IImporter
    {
        private const int NumberOfDepartments = 100;

        public Action<CompanyEntities, ILogger, IRandomGenerator> Get
        {
            get
            {
                return (db, logger, randomGenerator) =>
                {
                    for (int i = 0; i < NumberOfDepartments; i++)
                    {
                        db.Departments.Add(new Department()
                        {
                            Name = randomGenerator.GetRandomString(10, 50)
                        });

                        if (i % 10 == 0)
                        {
                            logger.Log(".");
                        }

                        if (i % 100 == 0)
                        {
                            db.SaveChanges();
                            db.Dispose();
                            db = new CompanyEntities();
                        }
                    }

                    db.SaveChanges();
                    logger.LogLine(string.Empty);
                };
            }
        }

        public string Message
        {
            get { return "Importing Departments"; }
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
