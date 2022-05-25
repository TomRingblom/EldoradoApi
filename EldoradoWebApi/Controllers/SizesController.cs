using EldoradoWebApi.Models.Sizes;
using EldoradoWebApi.Services;
using Microsoft.AspNetCore.Authorization;
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
            if (!ModelState.IsValid) return BadRequest();
            var size = await _service.CreateSize(model);
            return size == null! ? BadRequest($"A size with the given name already exists.") : Created("Size created successfully!", model);
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
            return size == null! ? NoContent() : Ok(size);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSize(int id, SizeUpdate model)
        {
            return await _service.UpdateSize(id, model) == null! ? BadRequest() : NoContent();
        }
        
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSize(int id)
        {
            return await _service.DeleteSize(id) == null! ? BadRequest("No size with the given id was found and could not be deleted.") : NoContent();
        }
    }
}
