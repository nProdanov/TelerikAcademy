using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace XMLParsing
{
    class ArtistsDomExtract
    {
        static void Main(string[] args)
        {
            var url = "..\\..\\..\\..\\catalogue.xml";
            var doc = new XmlDocument();
            doc.Load(url);

            XmlNode catalogue = doc.DocumentElement;

            var albums = catalogue.ChildNodes.Cast<XmlNode>();

            var artists = new Dictionary<string, int>();
            albums
                .Select(al => al["artist"].InnerText)
                .ToList()
                .ForEach(delegate (string artist)
            {
                if (artists.ContainsKey(artist))
                {
                    artists[artist] += 1;
                }
                else
                {
                    artists[artist] = 1;
                }
            });

            foreach (var entry in artists)
            {
                Console.WriteLine($"{entry.Key} has {entry.Value} albums in this catalogue.");
            }
        }
    }
}
