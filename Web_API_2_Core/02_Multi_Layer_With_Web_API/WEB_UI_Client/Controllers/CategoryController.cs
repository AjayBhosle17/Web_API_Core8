using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using WEB_UI_Client.Models;

namespace WEB_UI_Client.Controllers
    {
    public class CategoryController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _apiUrl;

        public CategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiUrl = _configuration.GetSection("ApiUrl").Value;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = new List<Category>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                HttpResponseMessage response = client.GetAsync("category").Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var matchCase = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
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

        [HttpPost]
        public IActionResult Create(Category category)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                var json = JsonSerializer.Serialize(category);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("category", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Error creating category");
                    return View(category);
                }
            }
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("Category ID is required");
            }

            Category category = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                HttpResponseMessage response = client.GetAsync($"category/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    var matchCase = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    category = JsonSerializer.Deserialize<Category>(content, matchCase);

                    if (category == null)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound("Category not found or Web API request failed");
                }
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest("Category ID is required");
            }

            Category category = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                HttpResponseMessage response = client.GetAsync($"category/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var matchCase = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    category = JsonSerializer.Deserialize<Category>(json, matchCase);
                }
                else
                {
                    return NotFound("API call failed");
                }

                if (category == null)
                {
                    return BadRequest("Invalid category ID");
                }
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                var json = JsonSerializer.Serialize<Category>(category);
                HttpResponseMessage request = client.PutAsync($"category/{category.Id}", new StringContent(json, Encoding.UTF8, "application/json")).Result;


                if (request.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Error updating category");
                    return View(category);
                }
            }
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Category ID is required");
            }

            Category category = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                HttpResponseMessage response = client.GetAsync($"category/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    var matchCase = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    category = JsonSerializer.Deserialize<Category>(json, matchCase);
                }
                else
                {
                    return NotFound("Category not found or Web API request failed");
                }
            }

            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                HttpResponseMessage response = client.DeleteAsync($"category/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Error deleting category");
                    return RedirectToAction("Index");
                }
            }
        }
    }

}
