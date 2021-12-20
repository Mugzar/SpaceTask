using IMDBprocessor;
using Newtonsoft.Json;

namespace MovieAPI.Models
{
    public class Movie
    {
		public string Title { get; set; }
		public string Directors { get; set; }
		public string Genres { get; set; }
		public double? ImDbRating { get; set; }
		public string? Image { get; set; }
		public string Plot { get; set; }
		public string IMDBtitleId { get; set; }

    }
}
