using System;
using Newtonsoft.Json;

using YoutubeVideos.Media;

namespace YoutubeVideos
{
    public class YoutubeVideo
    {
        [JsonProperty("yt:videoId")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("published")]
        public DateTime PublishedOn { get; set; }

        [JsonProperty("author")]
        public Author VideoAuthor { get; set; }

        [JsonProperty("link")]
        public VideoLink Link { get; set; }

        [JsonProperty("media:group")]
        public MediaInfo VideoMedia { get; set; }
    }
}
