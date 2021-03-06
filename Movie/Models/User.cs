using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public WatchList WatchList { get; set; }
    }
}
