using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace XMLParsing_Artist_Extract_XPath
{
    class ArtistsXPathExtract
    {
        static void Main(string[] args)
        {
            var url = "..\\..\\..\\..\\catalogue.xml";
            var doc = new XmlDocument();
            doc.Load(url);

            string xPathQuery = "/catalogue/album/artist";

            var artists = new Dictionary<string, int>();
            var artistList = doc.SelectNodes(xPathQuery).Cast<XmlNode>();
            
            artistList.Select(art => art.InnerText)
                .ToList()
                .ForEach(delegate (string artistName)
                {
                    if (artists.ContainsKey(artistName))
                    {
                        artists[artistName] += 1;
                    }
                    else
                    {
                        artists.Add(artistName, 1);
                    }
                });

            foreach (var entry in artists)
            {
                Console.WriteLine($"{entry.Key} has {entry.Value} albums in this catalogue.");
            }
        }
    }
}
