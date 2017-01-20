using System.Collections.Generic;

using Newtonsoft.Json;

namespace CodeFIrst.Parsers.ParsingModels
{
    public class DataJsonModel
    {
        [JsonProperty("data")]
        public List<SuperheroJsonModel> Superheroes { get; set; }
    }
}
