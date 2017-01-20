using System.Data.Entity;

namespace CodeFirst.Data.Factories
{
    public interface IEfUnitOfWorkFactory
    {
        IUnitOfWork CreateUnitOfWork(DbContext context);
    }
}
