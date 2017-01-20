using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using Company.Data;

namespace Company.DataImporter.CompanyQueries
{
    public class CompanyQueries : ICompanyQueries
    {
        private const int PageSize = 25;

        private CompanyEntities db;

        public CompanyQueries(CompanyEntities db)
        {
            this.db = db;
        }

        public XElement GetDepartments()
        {
            var xmlDepartments =
                this.db
                .Departments
                .Select(d => new
                {
                    name = d.Name,
                    employeesCount = d.Employees.Count
                })
                .OrderByDescending(d => d.employeesCount)
                .ToList();

            return this.GetXmlWithDepartments(xmlDepartments);
        }

        public XElement GetDepartments(int page)
        {
            var departmentsCount =
                this.db
                .Departments
                .Count();

            var skip = this.GetCorrectSkip(page, departmentsCount);

            var xmlDepartments =
                this.db
                .Departments
                .Select(d => new
                {
                    name = d.Name,
                    employeesCount = d.Employees.Count
                })
                .OrderByDescending(d => d.employeesCount)
                .Skip(skip)
                .Take(PageSize)
                .ToList();

            return this.GetXmlWithDepartments(xmlDepartments);
        }

        public XElement GetEmployeesFullInfo()
        {
            throw new NotImplementedException();
        }

        public XElement GetEmployeesFullInfo(int page)
        {
            throw new NotImplementedException();
        }

        public XElement GetEmployeesWithSalaryBetween(decimal from, decimal to)
        {
            var filteredXmlEmployees = db
            .Employees
            .Where(e => e.YearSalary >= from && e.YearSalary <= to)
            .Select(e => new
            {
                firstName = e.FirstName,
                lastName = e.LastName,
                salary = e.YearSalary
            })
            .ToList();

            return this.GetXmlWithEmployeesBySalary(filteredXmlEmployees);
        }

        public XElement GetEmployeesWithSalaryBetween(decimal from, decimal to, int page)
        {
            var numberOfFilteredEmployees =
                this.db
                .Employees
                .Where(e => e.YearSalary >= from && e.YearSalary <= to)
                .Count();

            var skip = this.GetCorrectSkip(page, numberOfFilteredEmployees);

            var filteredXmlEmployees =
                this.db
                .Employees
                .Where(e => e.YearSalary >= from && e.YearSalary <= to)
                .OrderBy(e => e.YearSalary)
                .Skip(skip)
                .Take(PageSize)
                .Select(e => new
                {
                    firstName = e.FirstName,
                    lastName = e.LastName,
                    salary = e.YearSalary
                })
                .ToList();

            return this.GetXmlWithEmployeesBySalary(filteredXmlEmployees);
        }

        private XElement GetXmlWithDepartments(IEnumerable<dynamic> departments)
        {
            var rootElement = new XElement("departments");

            foreach (var xmlDepartment in departments)
            {
                var nameElement = new XElement("name");
                nameElement.Value = xmlDepartment.name;

                var employeesCountElement = new XElement("employees-count");
                employeesCountElement.Value = xmlDepartment.employeesCount.ToString();

                var departmentElement = new XElement("department");
                departmentElement.Add(nameElement);
                departmentElement.Add(employeesCountElement);

                rootElement.Add(departmentElement);
            }

            return rootElement;
        }

        private int GetCorrectSkip(int page, int collectionCount)
        {
            if (page < 1)
            {
                page = 1;
            }
            var skip = (page - 1) * PageSize;

            if (skip > collectionCount)
            {
                skip = (collectionCount / PageSize) * PageSize;
            }

            return skip;
        }

        private XElement GetXmlWithEmployeesBySalary(IEnumerable<dynamic> employees)
        {
            var rootElement = new XElement("employees");

            foreach (var xmlEmployee in employees)
            {
                var firstNameElement = new XElement("first-name");
                firstNameElement.Value = xmlEmployee.firstName;

                var lastNameElement = new XElement("last-name");
                lastNameElement.Value = xmlEmployee.lastName;

                var yearSalaryElement = new XElement("year-salary");
                yearSalaryElement.Value = xmlEmployee.salary.ToString();

                var employeeElement = new XElement("employee");
                employeeElement.Add(firstNameElement);
                employeeElement.Add(lastNameElement);
                employeeElement.Add(yearSalaryElement);

                rootElement.Add(employeeElement);
            }

            return rootElement;
        }
    }
}
