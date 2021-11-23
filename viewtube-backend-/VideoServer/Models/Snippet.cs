using System;

namespace VideoServer.Models
{
    public class Snippet
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Thumbnails Thumbnails { get; set; }
        public string ChannelTitle { get; set; }
        public DateTime? PublishedAt { get; set; }
    }

}









