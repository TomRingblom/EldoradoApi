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
        public async Task<IActionResult> CreateOrder(CategoryCreate model)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateCategory(model);
                return Created("Category created successfully.", null);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await _service.GetCategories());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _service.GetCategoryById(id);
            if (order == null)
                return NoContent();

            return Ok(order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, CategoryUpdate model)
        {
            var order = await _service.UpdateCategory(id, model);
            if (order == null)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _service.DeleteCategory(id);
            if (order == null)
                return BadRequest("No category with the specified id was found and could not be deleted.");

            return NoContent();
        }
    }
}




//Brand
//Color
//Coupon
//Status