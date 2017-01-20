using System;

using NorthWindEntities.Data;

namespace Northwind_Twin
{
    public class NorthwindTwinCreation
    {
        public static void Main()
        {
            var northwindDbContext = new NorthwindEntities();

            var isCreated = northwindDbContext.Database.CreateIfNotExists();
            Console.WriteLine(isCreated);
        }
    }
}
