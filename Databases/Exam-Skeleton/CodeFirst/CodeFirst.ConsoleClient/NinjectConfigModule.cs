using System.Data.Entity;

using Ninject.Modules;
using Ninject.Extensions.Factory;

using CodeFirst.Data;
using CodeFirst.Data.Factories;
using CodeFirst.EfData;
using CodeFIrst.Parsers;

namespace CodeFirst.ConsoleClient
{
    public class NinjectConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<EfDbContext>();
            Bind<IEfDbContextFactory>().ToFactory().InSingletonScope();

            Bind(typeof(IRepository<>)).To(typeof(EfRepository<>));
            Bind<IUnitOfWork>().To<EfUnitOfWork>();

            Bind<IEfUnitOfWorkFactory>().ToFactory().InSingletonScope();
            //Bind<IEfRepositoryFactory<Type>>().ToFactory();
            //Bind<IEfRepositoryFactory<Type>>().ToFactory();
            //Bind<IEfRepositoryFactory<Type>>().ToFactory();
            //Bind<IEfRepositoryFactory<Type>>().ToFactory();
            //Bind<IEfRepositoryFactory<Type>>().ToFactory();

            Bind(typeof(IRepositoryFactory<>)).To(typeof(EfFactory<>));

            // Parsers 
            Bind<IXmlParser>().To<XmlParser>();
            Bind<IJsonParser>().To<JsonParser>();
        }
    }
}
