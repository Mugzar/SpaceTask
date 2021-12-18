using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public WatchList WatchList { get; set; }
    }
}
