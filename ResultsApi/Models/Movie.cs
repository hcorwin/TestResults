using Microsoft.AspNetCore.Authentication;

namespace ResultsApi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set;}
        public string VideoId { get; set; }
        public int Price { get; set; }

    }
}
