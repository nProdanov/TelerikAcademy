using System;
using System.Linq;
using System.Reflection;

using Company.Data;
using Company.DataImporter.Importers;
using Company.DataImporter.Logger;

namespace Company.DataImporter
{
    public class SampleDataImporter
    {
        private ILogger logger;
        private IRandomGenerator randomGenerator;

        private SampleDataImporter(ILogger logger, IRandomGenerator randomGenerator)
        {
            this.logger = logger;
            this.randomGenerator = randomGenerator;
        }

        public static SampleDataImporter Create(ILogger logger, IRandomGenerator randomGenerator)
        {
            return new SampleDataImporter(logger, randomGenerator);
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

                        var db = new CompanyEntities();
                        i.Get(db, this.logger, this.randomGenerator);
                    });
        }

    }
}
