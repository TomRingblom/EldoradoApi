using EldoradoWebApi.Models.Categories;
using EldoradoWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EldoradoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {

        private readonly ISubCategoryService _service;

        public SubCategoryController(ISubCategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubCategory(SubCategoryCreate model)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.CreateSubCategory(model);

                if(result == null)
                {
                    return BadRequest("A Subcategory with that name already exists");
                }

                return Created("SubCategory created successfully.", result);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetSubCategory()
        {
            return Ok(await _service.GetSubCategories());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _service.GetSubCategoryById(id);
            if (order == null)
                return NoContent();

            return Ok(order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, SubCategoryUpdate model)
        {
            var order = await _service.UpdateSubCategory(id, model);
            if (order == null)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _service.DeleteSubCategory(id);
            if (order == null)
                return BadRequest("No category with the specified id was found and could not be deleted.");

            return NoContent();
        }
    }
}
