namespace MovieAPI.Models
{
    public class WatchMovie
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }    

        public int WatchListId { get; set; }
        public WatchList WatchList { get; set; }

        public DateTime LastDateOffered { get; set; }
    }
}