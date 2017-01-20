using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CodeFIrst.Parsers
{
    public class JsonParser : IJsonParser
    {
        public IEnumerable<T> Parse<T>(string filePath)
        {
            var jsonText = File.ReadAllText(filePath);
            return JArray.Parse(jsonText)
                .Select(jObjCar =>
                {
                    return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(jObjCar));
                });
        }
    }
}
