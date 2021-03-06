using Microsoft.AspNetCore.Mvc;
using IMDBprocessor;
using System.Text.Json;
using Newtonsoft.Json;
using MovieAPI.Models;
using BaseProcessor;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly ILogger<MoviesController> _logger;
        private readonly IMovieServiceManager _movieServiceManager;

        public MoviesController(IMovieServiceManager movieServiceManager, ILogger<MoviesController> logger)
        {
            _logger = logger;
            _movieServiceManager = movieServiceManager;
        }
        

        // GET api/<MovieController>/title
        [HttpGet(Name = "Movies")]
        public ContentResult Get(string title)
        {
            List<Movie> movieList = new List<Movie>();
            var providerResponseList = _movieServiceManager.getListOfMedia(title);
            foreach(ProviderResponse movieItem in providerResponseList)
            {
                movieList.Add((Movie)movieItem);
            }
            return Content(JsonConvert.SerializeObject(movieList), "application/json");
        }

        
        // PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
