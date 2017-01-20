using System.Data.Entity;

namespace Test.Data
{
    public interface ITestDbContextFactory
    {
        DbContext CreateTestDbContext();
    }
}
