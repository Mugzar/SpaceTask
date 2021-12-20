using IMDBwatchList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MovieAPI.Controllers;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using MovieAPI.Models;
using System.Text;

namespace IMDBwatchList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory; 
        public HomeController(IHttpClientFactory httpClientFactory,ILogger<HomeController> logger)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public ActionResult Index()
        {
            ViewData["userId"] = 1;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["userId"] = 1;
            var client = _httpClientFactory.CreateClient("imdbAPI");
            HttpResponseMessage response = await client.GetAsync($"api/Movies?title={searchString}");
            var jsonString = await response.Content.ReadAsStringAsync();
            List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(jsonString);

            return View(movies);
        }

        [HttpPost]
        public async void AddToWatchlist(int userId,string movieId)
        {
            var client = _httpClientFactory.CreateClient("imdbAPI");
            var json = JsonConvert.SerializeObject(new { 
                Value = userId.ToString()
            });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync($"api/Watchlist?movieId={movieId}",data);

            //var jsonString = await response.Content.ReadAsStringAsync();
            //List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(jsonString);
        }
        public async Task<IActionResult> Privacy()
        {
            ViewData["userId"] = 1;
            var client = _httpClientFactory.CreateClient("imdbAPI");
            HttpResponseMessage response = await client.GetAsync($"api/Watchlist?id={ViewData["userId"]}");
            var jsonString = await response.Content.ReadAsStringAsync();
            List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(jsonString);
            return View(movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}