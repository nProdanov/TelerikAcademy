using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XMLParsing_All_Songs_Extract_XDocument
{
    class AllSongsXDocumentExtract
    {
        static void Main(string[] args)
        {
            var url = "..\\..\\..\\..\\catalogue.xml";

            var doc = XDocument.Load(url);

            var songs = new Dictionary<string, double>();

            doc
                .Root
                .Elements("album")
                .Elements("songs")
                .Elements("song")
                .ToList()
                .ForEach(song =>
                {
                    var songName = song.Element("title").Value;
                    var songDuration = double.Parse(song.Element("duration").Value);
                    songs.Add(songName, songDuration);
                });

            foreach (var entry in songs)
            {
                Console.WriteLine($"{entry.Key} - {entry.Value}");
            }
        }
    }
}
