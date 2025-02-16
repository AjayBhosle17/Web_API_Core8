using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Services.Interface;


namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {

        ICategoryService _service;
        IMemoryCache _cache; 

        public CategoryController(ICategoryService service , IMemoryCache cache)
        {
            _service = service;
            _cache = cache;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        
        public async Task<IActionResult> GetAll()
        {
          
           var categories = await _service.GetAll();
            return Ok(categories);
        }

        
        [HttpGet("{id:int}")]
        //[Route("{id:int}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]

        public async Task<IActionResult> GetById(int? id)
        {
            var category = await _service.GetById(id);

            if (category != null)
                return Ok(category);
            else
                return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> Create(CategoryModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Create(model);
                    return Ok(model);
                }
                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Update(CategoryModel model,int? id)
        {
            if (id > 0)
            {
                if (id == model.Id)
                {
                    if (ModelState.IsValid)
                    {
                        await _service.Update(model);
                        return Ok(model);
                    }
                    return BadRequest();
                }
                return BadRequest();
            }
            return BadRequest();
        }


        [HttpDelete("{id:int}")]

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            var product = await _service.GetById(id);
            if (product == null)
            {
                return NotFound("Product does not exist.");
            }

            await _service.Delete(id);

            return Ok("Product deleted successfully." );
        }


        [HttpGet]
        [Route("api/controller/ProductByCAtegoryName")]

        public async Task<IActionResult> GetProductByCategoryName(string str)
        {
            var data = str;
            return Ok(data);

        }
    }
}
