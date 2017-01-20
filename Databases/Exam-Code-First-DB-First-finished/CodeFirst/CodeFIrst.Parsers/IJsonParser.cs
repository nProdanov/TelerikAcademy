using CodeFIrst.Parsers.ParsingModels;
using System.Collections.Generic;

namespace CodeFIrst.Parsers
{
    public interface IJsonParser
    {
        IEnumerable<SuperheroJsonModel> Parse(string filePath);
    }
}