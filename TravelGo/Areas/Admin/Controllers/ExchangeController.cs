using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.MSIdentity.Shared;
using Newtonsoft.Json;

namespace TravelGo.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("[area]/[controller]/[action]")]
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=AZN&locale=en-gb"),
                Headers =
    {
        { "X-RapidAPI-Key", "8a0b4388afmsh7ff887cca690cdep151b55jsnbca9dc528df8" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<Root2>(body));
            }
        }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ExchangeRate
    {
        public string currency { get; set; }
        public string exchange_rate_buy { get; set; }
    }

    public class Root2
    {
        public List<ExchangeRate> exchange_rates { get; set; }
        public string base_currency_date { get; set; }
        public string base_currency { get; set; }
    }

}
