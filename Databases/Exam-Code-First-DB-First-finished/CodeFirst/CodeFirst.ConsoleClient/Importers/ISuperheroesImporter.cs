using System.Collections.Generic;
using CodeFIrst.Parsers.ParsingModels;

namespace CodeFirst.ConsoleClient.Importers
{
    public interface ISuperheroesImporter
    {
        void Import(IEnumerable<SuperheroJsonModel> superheroJsonModels);
    }
}