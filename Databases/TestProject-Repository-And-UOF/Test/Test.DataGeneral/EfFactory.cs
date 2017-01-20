using System.Data.Entity;
using Test.Data;

namespace Test.DataGeneral
{
    public class EfFactory<T> : IFactory<T> where T : class
    {
        private DbContext context;
        private ITestDbContextFactory contextFactory;
        private IRepositoryFactory<T> repositoryFactory;
        private IUnitOfWorkFactory uofFactory;

        public EfFactory(ITestDbContextFactory contextFactory, IRepositoryFactory<T> repositoryFactory, IUnitOfWorkFactory uofFactory)
        {
            this.contextFactory = contextFactory;
            this.context = this.contextFactory.CreateTestDbContext();
            this.repositoryFactory = repositoryFactory;
            this.uofFactory = uofFactory;
        }

        public IRepository<T> CreateRepository()
        {
            return this.repositoryFactory.CreateRepository(this.context);
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return this.uofFactory.CreateUof(this.context);
        }

        public void Reset()
        {
            this.context = this.contextFactory.CreateTestDbContext();
        }
    }
}
