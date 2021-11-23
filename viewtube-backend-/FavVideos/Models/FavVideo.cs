using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavVideos.Models
{
    public class FavVideo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty(PropertyName = "videoTitle")]
        public string VideoTitle { get; set; }

        [JsonProperty(PropertyName = "channelTitle")]
        public string ChannelTitle { get; set; }

        [JsonProperty(PropertyName = "videoId")]
        public string VideoId { get; set; }



    }
}

