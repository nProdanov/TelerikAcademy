using Newtonsoft.Json;

namespace YoutubeVideos.Media
{
    public class MediaContent
    {
        [JsonProperty("@url")]
        public string ContentUrl { get; set; }
    }
}
