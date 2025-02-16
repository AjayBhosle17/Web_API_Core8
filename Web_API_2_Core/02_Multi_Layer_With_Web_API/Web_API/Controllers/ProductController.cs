using DTO;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAll();
            if(products == null)
            {
                return BadRequest("Product List is Not Exit");
            }
            return Ok(products);
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetById(int? id)
        {
            if(id == null)
            {
                return BadRequest("Id is Invalid");
            }
            var product = await _productService.GetById(id);

            if (product == null) {

                return NotFound("Product Not Found");
            }
            return Ok(product);

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit(int? id, ProductModel model)
        {
            if (id == null || id <= 0)
            {
                return BadRequest("Invalid Product Id");
            }

            if (model == null || model.Id != id)
            {
                return BadRequest("Invalid Product Data");
            }

            await _productService.Edit(model);
            return Ok(true);
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id > 0)
            {
               
                var Product = await _productService.GetById(id);

                if (Product != null)
                {
                   await _productService.Delete(id);
                    return Ok(true);

                }
                else
                {
                    return NotFound("Product Is Not Exit");
                }
            }
            else
            {
                return BadRequest();
            }
            

        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                 _productService.Create(model);
                return Ok(model);
            }

            return BadRequest();
        }
    }
}
