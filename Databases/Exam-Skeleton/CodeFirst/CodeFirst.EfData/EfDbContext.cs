using System.Data.Entity;

namespace CodeFirst.EfData
{
    public class EfDbContext : DbContext
    {
        public EfDbContext()
            : base("NameOfConnString") // TODO: set correct conn string name  (ConsoleClient -> App.config)
        {

        }

        // TODO: Set virtual IDbSet-s 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // TODO: Set Indexes

            base.OnModelCreating(modelBuilder);
        }
    }
}
