using _01_Web_API_Intro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace _01_Web_API_Intro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        CoreDBContext _context;

        public CategoryController(CoreDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Category>))]
        public IActionResult GetAll()
        {
            List<Category> categories = _context.Categories.ToList();

            return Ok(categories);

        }
        [HttpGet("{id:int}")]
        //[Route("{id:int}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)] // Bad request
        [ProducesResponseType(404)] // Not found
        [ProducesResponseType(200)]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid category ID.");
            }

            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }

            return Ok(category);
        }


        [HttpPost]
        [ProducesResponseType(200,Type = typeof(Category))]
        [ProducesErrorResponseType(typeof(BadRequest))]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]

        public IActionResult Create(Category category) {

            if (category == null) {

                return BadRequest();
            }
            _context.Categories.Add(category);
            _context.SaveChanges();

            return Created();
        }

        [HttpPut]
        [ProducesResponseType(200,Type=typeof(Category))]
        [ProducesResponseType(400)]

        public IActionResult Edit(int? id ,Category category)
        {

            if (category == null && id==null)
            {

                return BadRequest();
            }
            if (id == category.Id)
            {

                _context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _context.SaveChanges();

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]


        public IActionResult Delete(int? id) { 
        
            if (id <= 0) { return NotFound(); }

            if (id == null)
            {
                return BadRequest();
            }
            var category = _context.Categories.Find(id);

            if (category == null) { 
            
                return BadRequest();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok("Sucessfully Deleted");
        }
    }   
}
