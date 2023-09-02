namespace Server.Models
{
    public class Anime
    {
        public string _id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double rating { get; set; }
        public int seasons { get; set; }
        public int episodes { get; set; }
        public string language { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
        public string imageUrl_wide { get; set; }
        public List<string> tags { get; set; } = new();
        public string publisher { get; set; }
    }
}
