using System.Data.Entity;

namespace CodeFirst.Data.Factories
{
    public interface IEfRepositoryFactory<T> 
        where T : class
    {
        IRepository<T> CreateRepository(DbContext context);
    }
}
