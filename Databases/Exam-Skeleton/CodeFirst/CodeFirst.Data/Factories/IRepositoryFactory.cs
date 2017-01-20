namespace CodeFirst.Data.Factories
{
    public interface IRepositoryFactory<T>
        where T : class
    {
        IRepository<T> CreateRepository();

        IUnitOfWork CreateUnitOfWork();

        void Reset();
    }
}
