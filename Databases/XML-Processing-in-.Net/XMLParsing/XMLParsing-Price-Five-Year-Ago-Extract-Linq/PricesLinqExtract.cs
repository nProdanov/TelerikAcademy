using System;
using System.Linq;
using System.Xml.Linq;

namespace XMLParsing_Price_Five_Year_Ago_Extract_Linq
{
    class PricesLinqExtract
    {
        static void Main(string[] args)
        {
            var yearNow = DateTime.Now.Year;
            var catalogueUrl = "..\\..\\..\\..\\catalogue.xml";

            var doc = XDocument.Load(catalogueUrl);

            var prices =
                     from album in doc.Descendants("album")
                     where int.Parse(album.Element("year").Value) + 5 < yearNow
                     select album.Element("price").Value;

            Console.WriteLine("Prices for albums before 5 years:");
            foreach (var price in prices)
            {
                Console.WriteLine(price);
            }
        }
    }
}
