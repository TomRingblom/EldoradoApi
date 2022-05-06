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
        public async Task<IActionResult> GetSubCategory(int id)
        {
            var result = await _service.GetSubCategoryById(id);


            if(result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Could not find Subcategory");
            }
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubCategories(int id)
        {
            var result = await _service.GetSubCategories();
            if (result == null)
                return NoContent();

            else
            {
                return Ok(result);
            }

            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubCategory(int id, SubCategoryUpdate model)
        {
            var result = await _service.UpdateSubCategory(id, model);
            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            var order = await _service.DeleteSubCategory(id);
            if (order == null)
                return BadRequest("No Subcategory with the specified id was found and could not be deleted.");

            return NoContent();
        }
    }
}
