using System.Data.Entity;
using System.Reflection;

using Ninject;

using CodeFirst.EfData;

namespace CodeFirst.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EfDbContext, Configuration>());
            var kernel = NinjectKernel();

        }

        private static IKernel NinjectKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
    }
}
