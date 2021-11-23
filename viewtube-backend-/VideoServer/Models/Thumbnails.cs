namespace VideoServer.Models
{
    public class Thumbnails
    {
        public Default Default { get; set; }

        public Medium Medium { get; set; }

    }

    public class Default
    {
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Medium
    {
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }


}









