using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace TravelGo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class VisitorApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VisitorApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://localhost:7228/api/Visitor");

                if (!response.IsSuccessStatusCode)
                {
                    // Handle non-successful response (e.g., 404, 500, etc.)
                    // You can return an error view or redirect to an error page.
                    return View("Error");
                }

                var result = await response.Content.ReadAsStringAsync();
                var visitors = JsonConvert.DeserializeObject<List<Visitor>>(result);
                return View(visitors);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                // You can use a logging framework like Serilog or ILogger
                // Also, consider returning an error view or redirecting to an error page.
                // For simplicity, we are just returning an error view here.
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Visitor visitor)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();

                // Serialize the Visitor object to JSON
                var jsonVisitor = JsonConvert.SerializeObject(visitor);

                // Create the HttpContent with JSON data
                var httpContent = new StringContent(jsonVisitor, Encoding.UTF8, "application/json");

                // Make the POST request to the API endpoint
                var response = await client.PostAsync("https://localhost:7228/api/Visitor", httpContent);

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Handle the successful response here if needed
                    return RedirectToAction("Index");
                }
                else
                {
                    // Handle the non-successful response here if needed
                    // For simplicity, we are just returning an error view here.
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                // You can use a logging framework like Serilog or ILogger
                // Also, consider returning an error view or redirecting to an error page.
                // For simplicity, we are just returning an error view here.
                return View("Error");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7228/api/Visitor/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"https://localhost:7228/api/Visitor/{id}");
                var result = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<Visitor>(result));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(Visitor visitor)
        {
            var client = _httpClientFactory.CreateClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(visitor), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7228/api/Visitor", content);
            //var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }

    public class Visitor
    {
        public int VisitorId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Mail { get; set; }
    }
}
