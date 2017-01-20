using Company.Data;
using Company.DataImporter.Logger;

namespace Company.DataImporter
{
    public class Startup
    {
        public static void Main()
        {
            ILogger consoleLogger = new ConsoleLogger();
            IRandomGenerator randomGenerator = new RandomGenerator();
            SampleDataImporter.Create(consoleLogger, randomGenerator).Import();
        }
    }
}
