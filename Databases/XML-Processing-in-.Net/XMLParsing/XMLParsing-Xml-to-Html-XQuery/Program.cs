using Saxon.Api;
using System.Xml;

namespace XMLParsing_Xml_to_Html_XQuery
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "..\\..\\..\\..\\catalogue.xml";
            var doc = new XmlDocument();
            doc.Load(url);

            var a = new XmlDestination();
        }
    }
}
