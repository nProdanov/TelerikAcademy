using Newtonsoft.Json;

namespace CodeFIrst.Parsers.ParsingModels
{
    public class CityJsonModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("planet")]
        public string Planet { get; set; }
    }
}
