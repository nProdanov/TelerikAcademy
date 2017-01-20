using Ninject.Modules;
using Test.DataGeneral;
using System.Data.Entity;
using Test.Data;
using Ninject.Extensions.Factory;
using Test.Models;

namespace Test.Client
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<TestDbContext>();
            Bind(typeof(IRepository<>)).To(typeof(EfRepository<>));
            Bind<IUnitOfWork>().To<EfUnitOfWork>();

            Bind<ITestDbContextFactory>().ToFactory();
            Bind(typeof(IFactory<>)).To(typeof(EfFactory<>));

            Bind<IRepositoryFactory<Customer>>().ToFactory();
            Bind<IRepositoryFactory<Product>>().ToFactory();

            Bind<IUnitOfWorkFactory>().ToFactory();
        }
    }
}
