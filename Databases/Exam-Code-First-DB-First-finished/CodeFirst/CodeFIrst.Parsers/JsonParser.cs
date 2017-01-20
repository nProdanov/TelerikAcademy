using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;
using CodeFIrst.Parsers.ParsingModels;

namespace CodeFIrst.Parsers
{
    public class JsonParser : IJsonParser
    {
        public IEnumerable<SuperheroJsonModel> Parse(string filePath)
        {
            var jsonText = File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<DataJsonModel>(jsonText);
            return data.Superheroes;
        }
    }
}
