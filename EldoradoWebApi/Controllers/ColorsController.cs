using EldoradoWebApi.Models.Colors;
using EldoradoWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EldoradoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _service;

        public ColorsController(IColorService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateColor(ColorCreate model)
        {
            if (ModelState.IsValid)
            {
                var color = await _service.CreateColor(model);
                if (color == null!)
                    return BadRequest($"A color with the name '{model.Name}' already exists");
                await _service.CreateColor(model);
                return Created($"Color: '{model.Name}', created successfully.", model);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetColors()
        {
            return Ok(await _service.GetColors());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColors(int id)
        {
            var color = await _service.GetColorById(id);
            if (color == null)
                return NoContent();

            return Ok(color);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColor(int id, ColorUpdate model)
        {
            var color = await _service.UpdateColor(id, model);
            if (color == null!)
                return BadRequest($"A color with the name '{model.Name}' already exists");
            if (color == null)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor(int id)
        {
            var color = await _service.DeleteColor(id);
            if (color == null)
                return BadRequest("No color with the specified id was found and could not be deleted.");

            return NoContent();
        }

    }
}
