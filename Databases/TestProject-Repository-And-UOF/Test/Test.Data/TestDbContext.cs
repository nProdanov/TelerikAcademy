using System.Data.Entity;
using Test.Models;

namespace Test.Data
{
    public class TestDbContext : DbContext
    {
        public TestDbContext()
            : base("TestDbContext")
        {

        }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<Customer> Customers { get; set; }
    }
}
