using System.Collections.Generic;

namespace CodeFirst.ConsoleClient.Importers
{
    public interface ICitiesImporter
    {
        void Import(IDictionary<string, string> cities);
    }
}