using Newtonsoft.Json;

namespace YoutubeVideos.Media
{
    public class MediaInfo
    {
        [JsonProperty("media:description")]
        public string Description { get; set; }

        [JsonProperty("media:content")]
        public MediaContent Content { get; set; }

        [JsonProperty("media:community")]
        public MediaCommunity CommunityStats { get; set; }
    }
}
