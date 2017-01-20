using System.Data.Entity;
using System.Reflection;

using Ninject;

using CodeFirst.EfData;
using CodeFirst.EfData.Migrations;
using CodeFirst.ConsoleClient.Exporter;
using System.IO;

namespace CodeFirst.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EfDbContext, Configuration>());
            var kernel = NinjectKernel();

            var importer = kernel.Get<DataImporter>();
            importer.Import();

            var exporter = kernel.Get<SuperheroesUniverseExporter>();
            var supperheroesWithPower = exporter.ExportSupperheroesWithPower("Utility belt");
            var superheroesByCity = exporter.ExportSuperheroesByCity("Gotham");
            var superheroDetails = exporter.ExportSuperheroDetails(1);
            var fractions = exporter.ExportFractions();
            var fractionDetails = exporter.ExportFractionDetails(1);
            var allSuperheroes = exporter.ExportAllSuperheroes();

            File.WriteAllText(
                $"..\\..\\..\\..\\03. Xml Files\\heroes-with-power.xml",
                supperheroesWithPower);
            File.WriteAllText(
                $"..\\..\\..\\..\\03. Xml Files\\heroes-by-city.xml",
                superheroesByCity);
            File.WriteAllText(
                 $"..\\..\\..\\..\\03. Xml Files\\heroe-details.xml",
                 superheroDetails);
            File.WriteAllText(
                $"..\\..\\..\\..\\03. Xml Files\\fractions.xml",
                fractions);
            File.WriteAllText(
                $"..\\..\\..\\..\\03. Xml Files\\all-superheroes.xml",
                allSuperheroes);
        }

        private static IKernel NinjectKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
    }
}
