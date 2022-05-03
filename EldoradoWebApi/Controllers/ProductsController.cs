using EldoradoApi.Data;
using EldoradoApi.Models.Products;
using EldoradoApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EldoradoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreate model)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateProduct(model);
                return Created("Product created succesfully", null);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _service.GetProducts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _service.GetProductById(id);

            if (product == null)
            {
                return NoContent();
            }

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductUpdate model)
        {
            var product = await _service.UpdateProduct(id, model);

            if (product == null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _service.DeleteProduct(id);

            if (product == null)
            {
                return BadRequest("No product with the specified id was found and could not be deleted.");
            }

            return NoContent();
        }
    }
}
