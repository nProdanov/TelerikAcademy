using Newtonsoft.Json;

namespace YoutubeVideos
{
    public class Author
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uri")]
        public string VideosUri { get; set; }

    }
}
