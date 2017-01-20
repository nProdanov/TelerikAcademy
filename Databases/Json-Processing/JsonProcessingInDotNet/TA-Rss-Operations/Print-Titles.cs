using System;
using System.Linq;
using System.Net;
using System.Xml.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Print_All_Videos_Titles
{
    class Program
    {
        static void Main(string[] args)
        {
            var youtubeRssFeedUrl = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            var XmlRssFeedFileName = "..\\..\\..\\taRss.xml";

            using (var client = new WebClient())
            {
                client.DownloadFile(youtubeRssFeedUrl, XmlRssFeedFileName);
            }

            var doc = XDocument.Load(XmlRssFeedFileName);
            var jsonRssFeed = JsonConvert.SerializeXNode(doc);
            var jObjectRssFeed = JObject.Parse(jsonRssFeed);

            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Video titles: ");
            jObjectRssFeed.Value<JToken>("feed")
                .Value<JToken>("entry")
                .Select(entry => entry.Value<string>("title"))
                .ToList()
                .ForEach(title =>
                {
                    Console.WriteLine(title);
                });
        }
    }
}
