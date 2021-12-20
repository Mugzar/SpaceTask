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

        public static explicit operator Movie(IMDBmovieResponse imdbObj)
        {
            Movie movieObj = new Movie()
            {
                Title = imdbObj.Title,
                Plot = imdbObj.Plot,
                Directors = imdbObj.Directors,
                Genres = imdbObj.Genres,
                Image = imdbObj.Image,
                ImDbRating = imdbObj.ImDbRating,
                IMDBtitleId = imdbObj.Id
            };
            return movieObj;
        } 

    }
}
