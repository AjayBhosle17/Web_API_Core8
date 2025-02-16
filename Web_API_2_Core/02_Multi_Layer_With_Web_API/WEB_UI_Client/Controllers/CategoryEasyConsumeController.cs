using Microsoft.AspNetCore.Mvc;
using WEB_UI_Client.Models;

namespace WEB_UI_Client.Controllers
{
    public class CategoryEasyConsumeController : Controller
    {
       private readonly IHttpCLientService _service;

        public CategoryEasyConsumeController(IHttpCLientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _service.GetAll<List<Category>>("category");
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category) {

            if (ModelState.IsValid)
            {
                await _service.Post<Category>("category", category);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Error in Adding Category");
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return BadRequest("Invalid category ID.");
            }

            var category = await _service.GetById<Category>($"category/{id}");

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category); 
            }

            try
            {
                await _service.Put($"category/{category.Id}",category);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while updating the category.");
                return View(category);
            }
        }

        [HttpGet]

        public async Task<IActionResult> Delete(int? id)
        {
            Category category= await _service.GetById<Category>($"category/{id}");
            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
           await _service.Delete($"category/{id}");
           return RedirectToAction("Index");

        }

        [HttpGet]
        
        public async Task<IActionResult> Details(int? id)
        {
            Category category =await _service.GetById<Category>($"category/{id}");
            return View(category);

        }

    }
}
