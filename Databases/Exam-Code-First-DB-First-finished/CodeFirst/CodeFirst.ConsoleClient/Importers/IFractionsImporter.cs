using System.Collections.Generic;

namespace CodeFirst.ConsoleClient.Importers
{
    public interface IFractionsImporter
    {
        void Import(IDictionary<string, string> fractions);
    }
}