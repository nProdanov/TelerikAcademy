using Newtonsoft.Json;

namespace YoutubeVideos.Media
{
    public class MediaStatistics
    {
        [JsonProperty("@views")]
        public int ViewsCount { get; set; }
    }
}
