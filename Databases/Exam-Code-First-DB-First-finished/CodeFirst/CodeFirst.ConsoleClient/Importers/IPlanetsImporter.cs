using System.Collections.Generic;

namespace CodeFirst.ConsoleClient.Importers
{
    public interface IPlanetsImporter
    {
        void Import(Dictionary<string, ICollection<string>> planets);
    }
}