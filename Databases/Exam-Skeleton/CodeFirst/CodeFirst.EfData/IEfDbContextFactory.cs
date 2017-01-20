using System.Data.Entity;

namespace CodeFirst.EfData
{
    public interface IEfDbContextFactory
    {
        DbContext CreateDbContext();
    }
}
