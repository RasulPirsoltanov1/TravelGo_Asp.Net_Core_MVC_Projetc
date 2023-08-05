using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TravelGo.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("[area]/[controller]/[action]")]
    public class ApiMovieController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies1.p.rapidapi.com/"),
                Headers ={
                          { "X-RapidAPI-Key", "8a0b4388afmsh7ff887cca690cdep151b55jsnbca9dc528df8" },
                          { "X-RapidAPI-Host", "imdb-top-100-movies1.p.rapidapi.com" },
                         },

            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<List<Movie>>(body));
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://imdb-top-100-movies1.p.rapidapi.com/?id={id}"),
                Headers =
    {
        { "X-RapidAPI-Key", "8a0b4388afmsh7ff887cca690cdep151b55jsnbca9dc528df8" },
        { "X-RapidAPI-Host", "imdb-top-100-movies1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<Movie>(body));
            }
        }
    }
    public class Movie
    {
        public string title { get; set; }
        public string id { get; set; }
        public List<List<string>> image { get; set; }
        public string description { get; set; }
        public int rank { get; set; }
        public string rating { get; set; }
        public string thumbnail { get; set; }
        public int year { get; set; }
    }

}
