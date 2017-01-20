using System;
using System.Linq;
using System.Collections.Generic;

using Company.Data;
using Company.DataImporter.Logger;

namespace Company.DataImporter.Importers
{
    public class ManagersImporter : IImporter
    {
        public Action<CompanyEntities, ILogger, IRandomGenerator> Get
        {
            get
            {
                return (db, logger, randomGenerator) =>
                {
                    var employeesIds = db
                        .Employees
                        .OrderBy(e => Guid.NewGuid())
                        .Select(e => e.Id)
                        .ToList();

                    var hierarchLevels = new int[] { 5, 10, 10, 15, 15, 15, 15, 15 };
                    var employeesCount = employeesIds.Count;

                    List<int> previousManagerIds = null;
                    var skip = 0;

                    foreach (var level in hierarchLevels)
                    {
                        var numberOfEmployeesForCurrentLevel = (int)(level * employeesCount / 100.0);

                        var employeeIdsForCurrentLevel =
                            employeesIds
                            .Skip(skip)
                            .Take(numberOfEmployeesForCurrentLevel)
                            .ToList();

                        var employeesForCurrentLevel =
                            db
                            .Employees
                            .Where(e => employeeIdsForCurrentLevel.Contains(e.Id))
                            .ToList();

                        for (int i = 0; i < employeesForCurrentLevel.Count; i++)
                        {
                            var currentEmployee = employeesForCurrentLevel[i];
                            var currentManagerId =
                                previousManagerIds == null ?
                                null :
                                (int?)previousManagerIds[randomGenerator.GetRandomNumber(0, previousManagerIds.Count - 1)];

                            currentEmployee.ManagerId = currentManagerId;
                        }

                        logger.Log(".");

                        db.SaveChanges();
                        db.Dispose();
                        db = new CompanyEntities();

                        previousManagerIds = employeeIdsForCurrentLevel;
                        skip += numberOfEmployeesForCurrentLevel;
                    }
                    logger.LogLine(string.Empty);
                };
            }
        }

        public string Message
        {
            get { return "Importing Managers"; }
        }

        public int Order
        {
            get { return 3; }
        }
    }
}
