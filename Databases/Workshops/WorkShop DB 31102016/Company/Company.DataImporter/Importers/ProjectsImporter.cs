using System;
using System.Linq;

using Company.Data;
using Company.DataImporter.Logger;
using System.Collections.Generic;

namespace Company.DataImporter.Importers
{
    public class ProjectsImporter : IImporter
    {
        private const int NumberOfProjects = 1000;

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
                    var currentEmployeeInd = 0;
                    for (int i = 0; i < NumberOfProjects; i++)
                    {
                        var numberOfEmployeesForCurrentProject = randomGenerator.GetRandomNumber(2, 8);
                        var employeesProjects = new List<EmployeesProject>();

                        for (int j = 0; j < numberOfEmployeesForCurrentProject; j++)
                        {
                            employeesProjects.Add(new EmployeesProject()
                            {
                                EmployeeId = employeeIds[currentEmployeeInd],
                                StartDate = randomGenerator.GetRandomDate(before: DateTime.Now.AddDays(-100)),
                                EndDate = randomGenerator.GetRandomDate(after: DateTime.Now.AddDays(-100))
                            });

                            currentEmployeeInd++;
                            if (currentEmployeeInd >= employeeIds.Count)
                            {
                                currentEmployeeInd = 0;
                            }
                        }

                        db.Projects.Add(new Project()
                        {
                            Name = randomGenerator.GetRandomString(5, 50),
                            EmployeesProjects = employeesProjects
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
            get { return "Importing Projects"; }
        }

        public int Order
        {
            get { return 4; }
        }
    }
}
