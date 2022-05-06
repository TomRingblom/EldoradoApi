using EldoradoWebApi.Models.Categories;
using EldoradoWebApi.Models.Orders;
using EldoradoWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EldoradoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryCreate model)
        {
            if (ModelState.IsValid)
            {
               var result = await _service.CreateCategory(model);

                if(result == null)
                {
                    return BadRequest("Category name already exists");
                }
                return Created("Category created successfully.", result);
            }
            return BadRequest("Modelstate invalid");
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            return Ok(await _service.GetCategories());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var order = await _service.GetCategoryById(id);
            if (order == null)
            {
                return BadRequest("Could not find Category");
            }
            else
            {
                return Ok(order);
            }
                

         
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryUpdate model)
        {
            var result = await _service.UpdateCategory(id, model);
            if (result == null)
                return BadRequest("");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _service.DeleteCategory(id);
            if (result == null)
                return BadRequest("No category with the specified id was found and could not be deleted.");

            return Ok(result);
        }
    }
}

