using System;
using System.Linq;

using Company.Data;
using Company.DataImporter.Logger;

namespace Company.DataImporter.Importers
{
    public class ReportsImporter : IImporter
    {
        public Action<CompanyEntities, ILogger, IRandomGenerator> Get
        {
            get
            {
                return (db, logger, randomGenerator) =>
                {
                    var employeeIds =
                        db
                        .Employees
                        .OrderBy(e => Guid.NewGuid())
                        .Select(e => e.Id)
                        .ToList();

                    foreach (var employeeId in employeeIds)
                    {
                        var numberOfReportsForCurrentEmployee = randomGenerator.GetRandomNumber(30, 70);

                        for (int i = 0; i < numberOfReportsForCurrentEmployee; i++)
                        {
                            db.Reports.Add(new Report()
                            {
                                EmployeeId = employeeId,
                                CheckedInTime = randomGenerator.GetRandomDate(before: DateTime.Now)
                            });
                        }

                        db.SaveChanges();
                        db.Dispose();
                        db = new CompanyEntities();
                        logger.Log(".");
                    }
                };
            }
        }

        public string Message
        {
            get { return "Importing Reports"; }
        }

        public int Order
        {
            get { return 5; }
        }
    }
}
