using BaseProcessor;
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
        private readonly IMovieServiceManager _movieServiceManager;

        public WatchlistController(MovieContext dbContext, ILogger<WatchlistController> logger, IMovieServiceManager movieServiceManager)
        {
            _dbContext = dbContext;
            _logger = logger;
            _movieServiceManager = movieServiceManager;
        }
        [HttpGet(Name = "Watchlist")]
        public ContentResult Get(int id)
        {
            try{
                List<Movie> movies = new List<Movie>();
                var result = _dbContext.WatchLists.Where(w => w.UserRefId == id).Include(w => w.WatchMovies).ThenInclude(m => m.Movie)
                    .FirstOrDefault();
                if (result == null) throw new Exception();
                foreach (var wm in result.WatchMovies)
                {
                    movies.Add(wm.Movie);
                }
                return Content(JsonConvert.SerializeObject(movies), "application/json");

            }
            catch(Exception ex)
            {
                return Content("No data");
            }
        }

        //POST api/<WatchlistController>
        [HttpPost(Name = "AddMovie")]
        public ContentResult Post([FromBody] Dto dto)
        {
            try
            {

                //check if exist
                ProviderResponse movieToAdd = _movieServiceManager.getMediaInfo(dto.MovieId);
                _dbContext.Movies.Add((Movie)movieToAdd);
                _dbContext.SaveChanges();
                WatchList wl = _dbContext.WatchLists.FirstOrDefault(wl => wl.UserRefId == dto.UserId);
                Movie movieItem = _dbContext.Movies.FirstOrDefault(m => m.IMDBtitleId == dto.MovieId);
                wl.WatchMovies.Add(new WatchMovie
                {
                    WatchListId = wl.WatchListID,
                    MovieId = movieItem.MovieID
                });
                _dbContext.SaveChanges();
                return Content(JsonConvert.SerializeObject(movieToAdd, Formatting.Indented),"application/json");
            }
            catch(Exception ex)
            {
                return Content("Error during fetching the data"); 
            }
            
        }
    }

    public class Dto
    {
        public int UserId { get; set; }
        public string MovieId { get; set; }
    }
}