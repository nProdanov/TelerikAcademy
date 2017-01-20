using System;
using System.Data.Entity;
using System.Linq;

using NorthWindEntities.Data;

namespace Northwind_Operations
{
    public class NorthwindOperations
    {
        public const string TaskSeparator = "--------------";

        public static void Main()
        {
            using (var northwindDbContext = new NorthwindEntities())
            {
                // Task 02
                AddCustomer(northwindDbContext);
                Console.WriteLine(TaskSeparator);

                UpdateCustomer(northwindDbContext);
                Console.WriteLine(TaskSeparator);

                // Relations confilct with delete

                // Task 03
                FindSpecificCustomers(northwindDbContext);
                Console.WriteLine(TaskSeparator);

                // Task 04
                FindSpecificCustomersByNativeSql(northwindDbContext);
                Console.WriteLine(TaskSeparator);

                // Task 05
                FilterSalesByRegionAndPeriod(northwindDbContext, "NM", new DateTime(1998, 1, 1), new DateTime(1996, 12, 31));
                Console.WriteLine(TaskSeparator);

                // Task 07
                var firstEmpl = GetFirstEmployee();
                firstEmpl.FirstName = "NewName";

                var isAttached = northwindDbContext.Entry(firstEmpl).State;
                Console.WriteLine($"State to northwindDbContext: {isAttached}");

                // When change state of firstEmpl, northwindDbContext will track changes of firstEmpl
                northwindDbContext.Entry(firstEmpl).State = EntityState.Modified;
                northwindDbContext.SaveChanges();

                var firstEmplAfterChanges = GetFirstEmployee();
                Console.WriteLine($"Employee name after changing state and save changes: {firstEmplAfterChanges.FirstName}");
            }
        }

        public static Employee GetFirstEmployee()
        {
            using (var anotherDbContext = new NorthwindEntities())
            {
                return anotherDbContext.Employees.Find(1);
            }
        }

        public static void FilterSalesByRegionAndPeriod(NorthwindEntities northwindDbContext, string region, DateTime startPeriod, DateTime endPeriod)
        {
            var filteredSales = northwindDbContext
                            .Orders
                            .Where(o => o.ShipRegion == region &&
                                   o.ShippedDate.Value.CompareTo(startPeriod) < 0 &&
                                   o.ShippedDate.Value.CompareTo(endPeriod) > 0)
                            .ToList();

            foreach (var sale in filteredSales)
            {
                Console.WriteLine(sale.ShipName);
                Console.WriteLine(sale.ShippedDate);
                Console.WriteLine(sale.ShipCountry);
                Console.WriteLine(sale.ShipAddress);
                Console.WriteLine(sale.ShipRegion);
                Console.WriteLine("--");
            }
        }

        public static void FindSpecificCustomersByNativeSql(NorthwindEntities northwindDbContext)
        {
            var sqlScript = @"SELECT
                            c.CustomerID,
                            c.ContactName, 
                            c.CompanyName, 
                            c.ContactTitle, 
                            c.Address, 
                            c.City, 
                            c.Region, 
                            c.PostalCode, 
                            c.Country, 
                            c.Phone,
                            c.Fax
                             FROM Customers as c
                            WHERE EXISTS
                            (SELECT * 
                             FROM Orders as o
                             WHERE c.CustomerID = o.CustomerID AND 
                       o.ShipCountry = 'Canada' AND 
                       YEAR(o.OrderDate) = 1997 )";

            var filteredCustomers = northwindDbContext.Database.SqlQuery<Customer>(sqlScript).ToList();

            foreach (var cust in filteredCustomers)
            {
                Console.WriteLine(cust.ContactName);
            }
        }

        public static void FindSpecificCustomers(NorthwindEntities northwindDbContext)
        {
            var specCustomers = northwindDbContext
                    .Customers
                    .Where(c => c.Orders
                                    .Any(o => o.OrderDate.Value.Year == 1997 &&
                                                o.ShipCountry == "Canada"))
                    .ToList();

            foreach (var cust in specCustomers)
            {
                Console.WriteLine(cust.ContactName);
                foreach (var ord in cust.Orders)
                {
                    var currYear = ord.ShippedDate != null ? ord.ShippedDate.Value.Year.ToString() : "no date";
                    Console.WriteLine($"{ord.ShipCountry}, {currYear}");
                }

                Console.WriteLine();
            }
        }

        public static void UpdateCustomer(NorthwindEntities northwindDbContext)
        {
            var customerToUpdate = northwindDbContext.Customers
                     .Where(c => c.CustomerID == "AUTRE")
                     .FirstOrDefault();
            customerToUpdate.ContactTitle = "Sales agent";

            var rowsAffected = northwindDbContext.SaveChanges();
            Console.WriteLine($"Rows affected: {rowsAffected}");
        }

        public static void AddCustomer(NorthwindEntities northwindDbContext)
        {
            var customerToAdd = new Customer();
            customerToAdd.CustomerID = "AUTRE";
            customerToAdd.CompanyName = "Coca Cola";
            customerToAdd.ContactName = "Josh Ua";
            customerToAdd.ContactTitle = "Owner";
            customerToAdd.Address = "st peter 666";
            customerToAdd.City = "Boston";
            customerToAdd.PostalCode = "11656";
            customerToAdd.Country = "USA";
            customerToAdd.Phone = "55773344";

            northwindDbContext.Customers.Add(customerToAdd);

            var rowsAffected = northwindDbContext.SaveChanges();
            Console.WriteLine($"Rows affected: {rowsAffected}");
        }
    }
}
