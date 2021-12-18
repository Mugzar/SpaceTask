using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAPI.Models
{
    public class WatchList
    {
        public int WatchListID { get; set; }

        [ForeignKey("User")]
        public int UserRefId { get; set; }
        public User User { get; set; }
        public virtual ICollection<WatchMovie> WatchMovies { get; set; }=new List<WatchMovie>();
    }
}