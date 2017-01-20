using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CodeFIrst.Parsers
{
    public class XmlParser : IXmlParser
    {
        public IEnumerable<T> Parse<T>(string filePath, string rootElement)
        {
            var result = this.Deserialize<T>(filePath, rootElement);
            return result;
        }

        private IEnumerable<TModel> Deserialize<TModel>(string fileName, string rootElement)
        {
            var serializer = new XmlSerializer(typeof(List<TModel>), new XmlRootAttribute(rootElement));
            IEnumerable<TModel> result;
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                result = (IEnumerable<TModel>)serializer.Deserialize(fs);
            }

            return result;
        }
    }
}
