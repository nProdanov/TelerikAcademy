using System.Data.Entity;

namespace Test.DataGeneral
{
    public interface IRepositoryFactory<T> where T : class
    {
        IRepository<T> CreateRepository(DbContext context);
    }
}
