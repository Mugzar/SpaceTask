using Microsoft.AspNetCore.Mvc;
using IMDBprocessor;
using System.Text.Json;
using Newtonsoft.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly ILogger<MoviesController> _logger;

        public MoviesController(ILogger<MoviesController> logger)
        {
            _logger = logger;
        }
        //// GET: api/<ValuesController>
        //[HttpGet(Name = "Movies")]
        //public IEnumerable<string> Get()
        //{
        //    MovieProcessor proc = new MovieProcessor();
        //    List<string> res = new List<string>();
        //    foreach(var m in proc.GetAll("the"))
        //    {
        //        res.Add(m.Title);
        //    }
        //    return res;
        //}

        // GET api/<MovieController>/title
        [HttpGet(Name = "GetMovieList")]
        public string Get(string title)
        {
            MovieProcessor proc = new MovieProcessor(); 
            return JsonConvert.SerializeObject(proc.GetAll(title), Formatting.Indented);
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
