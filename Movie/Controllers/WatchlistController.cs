using IMDBprocessor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;
using Newtonsoft.Json;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchlistController : ControllerBase
    {
        private readonly ILogger<WatchlistController> _logger;
        private readonly MovieContext _dbContext;

        public WatchlistController(MovieContext dbContext, ILogger<WatchlistController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet(Name = "GetWatchlist")]
        public string Get(int id)
        {
            try{
                List<Movie> movies = new List<Movie>();
                var result = _dbContext.WatchLists.Where(w => w.UserRefId == id).Include(w => w.WatchMovies).ThenInclude(m => m.Movie)
                    .FirstOrDefault();
                foreach (var wm in result.WatchMovies)
                {
                    movies.Add(wm.Movie);
                }
                return JsonConvert.SerializeObject(movies, Formatting.Indented);
            }
            catch(Exception ex)
            {
                return "No data";
            }
        }

        //POST api/<WatchlistController>
        [HttpPost(Name = "AddMovie")]
        public string Post(int userId, string movieId)
        {
            try
            {

                //check if exist
                MovieProcessor proc = new MovieProcessor();
                IMDBmovieResponse movieToAdd = proc.GetInfo(movieId);
                var movie = new Movie()
                {
                    Title = movieToAdd.Title,
                    Description = movieToAdd.Plot,
                    Director = movieToAdd.Directors,
                    Genre = movieToAdd.Genres,
                    Poster = movieToAdd.Image,
                    Rating = movieToAdd.ImDbRating,
                    IMDBtitleId= movieId
                };
                _dbContext.Movies.Add(movie);
                _dbContext.SaveChanges();
                WatchList wl = _dbContext.WatchLists.FirstOrDefault(wl => wl.UserRefId == userId);
                Movie movieItem = _dbContext.Movies.FirstOrDefault(m => m.IMDBtitleId == movieId);
                wl.WatchMovies.Add(new WatchMovie
                {
                    WatchListId = wl.WatchListID,
                    MovieId = movieItem.MovieID
                });
                _dbContext.SaveChanges();
                return JsonConvert.SerializeObject(movieToAdd, Formatting.Indented);
            }
            catch(Exception ex)
            {
                return "Error during fetching the data";
            }
            
        }
    }
}