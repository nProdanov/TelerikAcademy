using Ninject;

namespace DbFirst.DataImporter
{
    public class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel(new ConfigNinjectModule());

            kernel.Get<IDataImporter>().Import();
        }
    }
}
