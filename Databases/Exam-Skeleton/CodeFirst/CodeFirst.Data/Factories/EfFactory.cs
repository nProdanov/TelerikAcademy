using System.Data.Entity;

using CodeFirst.EfData;

namespace CodeFirst.Data.Factories
{
    public class EfFactory<T> : IRepositoryFactory<T>
        where T : class
    {
        private DbContext dbContext;
        private IEfDbContextFactory efDbContextFactory;
        private IEfRepositoryFactory<T> efRepositoryFactory;
        private IEfUnitOfWorkFactory efUnitOfWorkFactory;

        public EfFactory(
            IEfDbContextFactory efDbContextFactory, 
            IEfRepositoryFactory<T> efRepositoryFactory, 
            IEfUnitOfWorkFactory efUnitOfWorkFactory)
        {
            this.efDbContextFactory = efDbContextFactory;
            this.efRepositoryFactory = efRepositoryFactory;
            this.efUnitOfWorkFactory = efUnitOfWorkFactory;

            this.dbContext = efDbContextFactory.CreateDbContext();
        }

        public IRepository<T> CreateRepository()
        {
            return this.efRepositoryFactory.CreateRepository(this.dbContext);
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return this.efUnitOfWorkFactory.CreateUnitOfWork(this.dbContext);
        }

        public void Reset()
        {
            this.dbContext = this.efDbContextFactory.CreateDbContext();
        }
    }
}
