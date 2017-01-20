using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Cars;

namespace Import_Cars_From_Json
{
    public class JsonToPoco
    {
        public static void Main(string[] args)
        {
            var jsonText = GetJsonAsText();
            var cars = CarJsonParser(jsonText);
        }

        public static IEnumerable<Car> CarJsonParser(string jsonText)
        {
            return JArray.Parse(jsonText)
                .Select(jObjCar =>
                {
                    return JsonConvert.DeserializeObject<Car>(JsonConvert.SerializeObject(jObjCar));
                });
        }

        public static string GetJsonAsText()
        {
            string jsonText;

            while (true)
            {
                try
                {
                    var numberOfFile = GetFileNumber();
                    string jsonFileUrl = $"..\\..\\data.{numberOfFile}.json";
                    jsonText = File.ReadAllText(jsonFileUrl);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid number of file");
                    continue;
                }
            }

            return jsonText;
        }

        public static string GetFileNumber()
        {
            Console.WriteLine("Please enter the number of json file to read");
            return Console.ReadLine();
        }
    }
}
