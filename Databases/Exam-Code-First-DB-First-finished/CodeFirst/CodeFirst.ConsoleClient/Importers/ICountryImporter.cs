using System.Collections.Generic;

namespace CodeFirst.ConsoleClient.Importers
{
    public interface ICountryImporter
    {
        void Import(IDictionary<string, string> countries);
    }
}