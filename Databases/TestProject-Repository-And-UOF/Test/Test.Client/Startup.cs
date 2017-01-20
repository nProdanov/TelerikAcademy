using System.Data.Entity;
using System.Reflection;

using Ninject;

using Test.Data;
using Test.Data.Migrations;

namespace Test.Client
{
    public class Startup
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TestDbContext, Configuration>());

            var kernel = NinjectKernel();

            var importer = kernel.Get<CustomersImporter>();
            importer.Import();
            
        }

        private static IKernel NinjectKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
    }
}
