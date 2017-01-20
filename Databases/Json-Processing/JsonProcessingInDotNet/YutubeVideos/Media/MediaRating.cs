using Newtonsoft.Json;

namespace YoutubeVideos.Media
{
    public class MediaRating
    {
        [JsonProperty("@average")]
        public double Average { get; set; }
    }
}
