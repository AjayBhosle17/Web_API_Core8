using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Implementation;
using Services.Interface;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
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


        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]


        public async Task<IActionResult> Update(int? id,CategoryModel model)
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

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id > 0)
            {
                try
                {
                    var category = await _service.GetById(id);

                    if (category != null)
                    {
                        _service.Delete(id);
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch
                {
                    return BadRequest();
                }
            }
            return BadRequest();

        }

    }
}
