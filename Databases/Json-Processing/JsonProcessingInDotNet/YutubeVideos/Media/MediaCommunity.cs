using Newtonsoft.Json;

namespace YoutubeVideos.Media
{
    public class MediaCommunity
    {
        [JsonProperty("media:statistics")]
        public MediaStatistics Statistics { get; set; }

        [JsonProperty("media:starRating")]
        public MediaRating Rating { get; set; }
    }
}
