using EldoradoWebApi.Models.Sizes;
using EldoradoWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EldoradoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly ISizeService _service;

        public SizesController(ISizeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSize(SizeCreate model)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateSize(model);
                return Created("Size created successfully.", null);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetSizes()
        {
            return Ok(await _service.GetSizes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSize(int id)
        {
            var size = await _service.GetSizeById(id);
            if (size == null)
                return NoContent();

            return Ok(size);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSize(int id, SizeUpdate model)
        {
            var size = await _service.UpdateSize(id, model);
            if (size == null)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var size = await _service.DeleteSize(id);
            if (size == null)
                return BadRequest("No size with the specified id was found and could not be deleted.");

            return NoContent();
        }
    }
}
