using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WEB_UI_Client.Models;

namespace WEB_UI_Client.Controllers
{
    public class CategoryController : Controller
    {
        IConfiguration _configuration;
        string _apiUrl;
   
        public CategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiUrl = _configuration.GetSection("ApiUrl").Value;

          
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = new List<Category>();   
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);

                HttpResponseMessage response =  client.GetAsync("category").Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;

                    var matchCase = new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive =true
                    };

                    categories = JsonSerializer.Deserialize<List<Category>>(result, matchCase);

                }
                return View(categories);
            }

            
        }
        
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

    }
}
