using System.Data.Entity;

using Ninject.Modules;
using Ninject.Extensions.Factory;

using CodeFirst.Data;
using CodeFirst.EfData;
using CodeFIrst.Parsers;
using CodeFirst.Models;
using CodeFirst.ConsoleClient.Importers;
using CodeFirst.ConsoleClient.Exporter;

namespace CodeFirst.ConsoleClient
{
    public class NinjectConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<EfDbContext>().InSingletonScope();
            Bind<IEfDbContextFactory>().ToFactory().InSingletonScope();

            Bind(typeof(IRepository<>)).To(typeof(EfRepository<>));
            Bind<IUnitOfWork>().To<EfUnitOfWork>();

            // Parsers 
            Bind<IJsonParser>().To<JsonParser>();

            //Importers
            Bind<IPowersImporter>().To<PowersImporter>();
            Bind<IFractionsImporter>().To<FractionsImporter>();
            Bind<IPlanetsImporter>().To<PlanetsImporter>();
            Bind<ICountryImporter>().To<CountryImporter>();
            Bind<ICitiesImporter>().To<CitiesImporter>();
            Bind<ISuperheroesImporter>().To<SuperheroesImporter>();

            Bind<ISuperheroesUniverseExporter>().To<SuperheroesUniverseExporter>();

        }
    }
}
