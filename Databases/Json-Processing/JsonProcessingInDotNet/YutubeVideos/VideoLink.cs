using Newtonsoft.Json;

namespace YoutubeVideos
{
    public class VideoLink
    {
        [JsonProperty("@href")]
        public string Href { get; set; }
    }
}
