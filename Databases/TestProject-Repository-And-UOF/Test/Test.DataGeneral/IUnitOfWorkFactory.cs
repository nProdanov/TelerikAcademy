using System.Data.Entity;

namespace Test.DataGeneral
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork CreateUof(DbContext context);
    }
}
