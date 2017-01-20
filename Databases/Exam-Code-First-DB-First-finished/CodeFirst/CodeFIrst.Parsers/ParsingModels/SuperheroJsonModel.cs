using Newtonsoft.Json;
using System.Collections.Generic;

namespace CodeFIrst.Parsers.ParsingModels
{
    public class SuperheroJsonModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("secretIdentity")]
        public string SecretIdentity { get; set; }

        [JsonProperty("city")]
        public virtual CityJsonModel City { get; set; }

        [JsonProperty("alignment")]
        public string Alignment { get; set; }

        [JsonProperty("story")]
        public string Story { get; set; }

        [JsonProperty("powers")]
        public virtual List<string> Powers { get; set; }

        [JsonProperty("fractions")]
        public virtual List<string> Fractions { get; set; }
    }
}
