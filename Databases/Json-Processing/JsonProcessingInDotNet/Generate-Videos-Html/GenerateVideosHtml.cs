using System.IO;
using System.Linq;
using System.Net;
using System.Web.UI;
using System.Xml.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using YoutubeVideos;

namespace Generate_Videos_Html
{
    class GenerateVideosHtml
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

            var videos = jObjectRssFeed.Value<JToken>("feed")
                    .Value<JToken>("entry")
                    .Select(entry => { return JsonConvert.DeserializeObject<YoutubeVideo>(JsonConvert.SerializeObject(entry)); })
                    .ToList();

            var stringWriter = new StringWriter();

            using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Html);

                writer.RenderBeginTag(HtmlTextWriterTag.Head);
                writer.AddAttribute("charset", "utf-8");
                writer.RenderBeginTag(HtmlTextWriterTag.Meta);
                writer.RenderEndTag();

                writer.RenderBeginTag(HtmlTextWriterTag.Body);
                foreach (var video in videos)
                {
                    writer.AddStyleAttribute(HtmlTextWriterStyle.BorderColor, "black");
                    writer.AddStyleAttribute(HtmlTextWriterStyle.BorderStyle, "solid");
                    writer.AddStyleAttribute(HtmlTextWriterStyle.BorderWidth, "1px");
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "video-wrapper");
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);

                    writer.RenderBeginTag(HtmlTextWriterTag.H3);
                    writer.Write(video.Title);
                    writer.RenderEndTag();

                    writer.AddAttribute(HtmlTextWriterAttribute.Src, video.VideoMedia.Content.ContentUrl);
                    writer.RenderBeginTag(HtmlTextWriterTag.Iframe);
                    writer.RenderBeginTag(HtmlTextWriterTag.P);
                    writer.Write("Your browser doesn't support iframes");  //old browsers
                    writer.RenderEndTag();
                    writer.RenderEndTag();

                    writer.RenderBeginTag(HtmlTextWriterTag.H3);
                    writer.Write("Youtube video page: ");
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, video.Link.Href);
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.Write(video.Link.Href);
                    writer.RenderEndTag();
                    writer.RenderEndTag();

                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "community-stats");
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);
                    writer.RenderBeginTag(HtmlTextWriterTag.H4);
                    writer.Write($"Rating: {video.VideoMedia.CommunityStats.Rating.Average}");
                    writer.RenderEndTag();

                    writer.RenderBeginTag(HtmlTextWriterTag.H4);
                    writer.Write($"Views: {video.VideoMedia.CommunityStats.Statistics.ViewsCount}");
                    writer.RenderEndTag();

                    writer.RenderBeginTag(HtmlTextWriterTag.H4);
                    writer.Write("Published by:");
                    writer.AddAttribute(HtmlTextWriterAttribute.Href, video.VideoAuthor.VideosUri);
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.Write(video.VideoAuthor.Name);
                    writer.RenderEndTag();
                    writer.RenderEndTag();

                    writer.RenderBeginTag(HtmlTextWriterTag.H4);
                    writer.Write($"Published on: {video.PublishedOn.ToShortDateString()} {video.PublishedOn.ToShortTimeString()}");
                    writer.RenderEndTag();

                    writer.RenderBeginTag(HtmlTextWriterTag.P);
                    writer.RenderBeginTag(HtmlTextWriterTag.Strong);
                    writer.Write("Description");
                    writer.RenderEndTag();
                    writer.RenderEndTag();

                    writer.Write(video.VideoMedia.Description);

                    writer.RenderEndTag();

                    writer.RenderEndTag();
                }
                writer.RenderEndTag();
                writer.RenderEndTag();
            }

            File.WriteAllText("..\\..\\..\\taRss.html", stringWriter.ToString());
        }
    }
}
