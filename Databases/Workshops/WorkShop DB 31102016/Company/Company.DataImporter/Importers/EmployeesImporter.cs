using System;
using System.Linq;

using Company.Data;
using Company.DataImporter.Logger;

namespace Company.DataImporter.Importers
{
    public class EmployeesImporter : IImporter
    {
        private const int NumberOfEmployees = 5000;

        public Action<CompanyEntities, ILogger, IRandomGenerator> Get
        {
            get
            {
                return (db, logger, randomGenerator) =>
                {
                    var departmentsIds = db.Departments
                    .Select(d => d.Id)
                    .ToList();

                    for (int i = 0; i < NumberOfEmployees; i++)
                    {
                        var randomDepartmendIdIndex = randomGenerator.GetRandomNumber(0, departmentsIds.Count - 1);
                        db.Employees.Add(new Employee()
                        {
                            FirstName = randomGenerator.GetRandomString(5, 20),
                            LastName = randomGenerator.GetRandomString(5, 20),
                            YearSalary = randomGenerator.GetRandomNumber(50000, 200000),
                            DepartmentId = departmentsIds[randomDepartmendIdIndex]
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
            get { return "Importing Employees"; }
        }

        public int Order
        {
            get { return 2; }
        }
    }
}
