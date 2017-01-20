using System.Collections.Generic;

namespace CodeFirst.ConsoleClient.Importers
{
    public interface IPowersImporter
    {
        void Import(IEnumerable<string> powers);
    }
}