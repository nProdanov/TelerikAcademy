using System;
using System.Collections.Generic;
using System.Xml;

namespace XMLParsing_All_Songs_Extract_XmlReader
{
    class AllSongsXReaderExtract
    {
        static void Main(string[] args)
        {
            Console.WriteLine("All songs in the catalogue:");

            var url = "..\\..\\..\\..\\catalogue.xml";

            var songs = new Dictionary<string, double>();
            using (XmlReader reader = XmlReader.Create(url))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement() &&
                        reader.Name == "title")
                    {
                        var songName = reader.ReadElementString();
                        reader.Read();
                        var songDuration = double.Parse(reader.ReadElementString());
                        songs.Add(songName, songDuration);
                    }
                }
            }

            foreach (var entry in songs)
            {
                Console.WriteLine($"{entry.Key} - {entry.Value}");
            }
        }
    }
}
