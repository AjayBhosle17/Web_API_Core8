using Microsoft.AspNetCore.Mvc;
using WEB_UI_Client.Models;

namespace WEB_UI_Client.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpCLientService _httpCLientService;

        public ProductController(IHttpCLientService httpCLientService)
        {
            _httpCLientService = httpCLientService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Product> Products =await _httpCLientService.GetAll<List<Product>>("product");
            return View(Products);
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> Details(int? id)
        {
            var product = await _httpCLientService.GetById<Product>($"product/{id}");
            if (product == null) {

                return BadRequest();
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _httpCLientService.GetAll<List<Category>>("category");
            ViewBag.Categories = categories;
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid) {

                
               await _httpCLientService.Post<Product>("product", product);
                return RedirectToAction("Index");

            }
            ModelState.AddModelError("", "Error in Adding Category");
            return View(product);

        }

        [HttpGet]
        public async  Task<IActionResult> Edit(int? id)
        {
            if (id>0 && id!=null)
            {
                var product = await _httpCLientService.GetById<Product>($"Product/{id}");

                if (product != null) { 
                
                    return View(product);

                }
                else
                {
                    return NotFound();
                }

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {

               await _httpCLientService.Put($"product/{product.Id}", product);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Product Not Exit");
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var product = await _httpCLientService.GetById<Product>($"product/{id}");

            if (product != null)
            {
                return View(product);
            }

            return BadRequest();
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var product = await _httpCLientService.GetById<Product>($"product/{id}");

            if (product != null)
            {
              await  _httpCLientService.Delete($"product/{id}");
                return RedirectToAction("Index");
            }

            return BadRequest();
        }
    }
}
