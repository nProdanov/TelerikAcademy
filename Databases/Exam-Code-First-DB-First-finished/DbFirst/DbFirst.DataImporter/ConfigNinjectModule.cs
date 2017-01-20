using Ninject.Modules;

using DbFirst.DataImporter.RandomGenerator;
using DbFirst.DataImporter.Logger;

namespace DbFirst.DataImporter
{
    public class ConfigNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataImporter>().To<DataImporter>().InSingletonScope();
            Bind<IRandomGenerator>().To<RandomGenerator.RandomGenerator>().InSingletonScope();
            Bind<ILogger>().To<ConsoleLogger>();
        }
    }
}
