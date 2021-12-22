using BaseProcessor;
using IMDBprocessor;
using Newtonsoft.Json;

namespace MovieAPI.Models
{
    public class Movie
    {
		[JsonIgnore]
		public int MovieID { get; set; }
		public string Title { get; set; }
		public string Directors { get; set; }
		public string Genres { get; set; }
		public double? ImDbRating { get; set; }
		public string? Image { get; set; }
		public string Plot { get; set; }
		public string IMDBtitleId { get; set; }
		[JsonIgnore]
		public virtual ICollection<WatchMovie> WatchMovies { get; set; }=new List<WatchMovie>();

        public static explicit operator Movie(ProviderResponse serviceObj)
        {
            Movie movieObj = new Movie()
            {
                Title = serviceObj.Name,
                Plot = serviceObj.Description,
                Directors = serviceObj.Author,
                Genres = serviceObj.Genre,
                Image = serviceObj.Image,
                ImDbRating = serviceObj.Rating,
                IMDBtitleId = serviceObj.Id
            };
            return movieObj;
        } 

    }
}
