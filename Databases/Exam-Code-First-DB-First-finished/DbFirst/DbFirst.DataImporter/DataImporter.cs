using System;
using System.Linq;
using System.Reflection;

using DbFirst.DataImporter.Logger;
using DbFirst.DataImporter.Importers;
using DbFirst.DataImporter.RandomGenerator;
using DbFirst.Data;

namespace DbFirst.DataImporter
{
    public class DataImporter : IDataImporter
    {
        private ILogger logger;
        private IRandomGenerator randomGenerator;

        public DataImporter(ILogger logger, IRandomGenerator randomGenerator)
        {
            this.logger = logger;
            this.randomGenerator = randomGenerator;
        }

        public void Import()
        {
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(
                    t => typeof(IImporter).IsAssignableFrom(t) &&
                        !t.IsInterface &&
                        !t.IsAbstract)
                    .Select(Activator.CreateInstance)
                    .OfType<IImporter>()
                    .OrderBy(i => i.Order)
                    .ToList()
                    .ForEach(i =>
                    {
                        this.logger.Log(i.Message);

                        var db = new ComputersEntities();
                        i.Get(db, this.logger, this.randomGenerator);
                    });
        }
    }
}
