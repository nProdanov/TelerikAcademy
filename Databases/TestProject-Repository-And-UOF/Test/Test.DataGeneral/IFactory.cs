namespace Test.DataGeneral
{
    public interface IFactory<T> where T : class
    {
        IRepository<T> CreateRepository();

        IUnitOfWork CreateUnitOfWork();

        void Reset();
    }
}
