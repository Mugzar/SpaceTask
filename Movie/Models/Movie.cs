using Newtonsoft.Json;

namespace MovieAPI.Models
{
    public class Movie
    {
		public int MovieID { get; set; }
		public string Title { get; set; }
		public string Director { get; set; }
		public string Genre { get;set; }
		public double? Rating { get; set; }
		public string? Poster { get; set; }
		public string Description { get; set; }
		public string IMDBtitleId { get; set; }
		[JsonIgnore]
		public virtual ICollection<WatchMovie> WatchMovies { get; set; }=new List<WatchMovie>();
	}
}
