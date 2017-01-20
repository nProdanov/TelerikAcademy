using System;
using System.Xml;

namespace XMLParsing_Prices_Five_Year_Ago_Extract_XPath
{
    class PricesXPathExtract
    {
        static void Main(string[] args)
        {
            var yearNow = DateTime.Now.Year;
            var catalogueUrl = "..\\..\\..\\..\\catalogue.xml";

            XmlDocument doc = new XmlDocument();
            doc.Load(catalogueUrl);

            var xPathPrices = $"/catalogue/album[year+5<{yearNow}]/price";

            var prices = doc.SelectNodes(xPathPrices);

            Console.WriteLine("Prices for albums before 5 years:");
            foreach (XmlElement price in prices)
            {
                Console.WriteLine(price.InnerText);
            }
        }
    }
}
