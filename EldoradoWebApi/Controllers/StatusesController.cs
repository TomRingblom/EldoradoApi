using EldoradoWebApi.Models.Status;
using EldoradoWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EldoradoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private readonly IStatusService _service;

        public StatusesController(IStatusService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStatus(StatusCreate model)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateStatus(model);
                return Created("Status created successfully.", null);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetStatuses()
        {
            return Ok(await _service.GetStatuses());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatus(int id)
        {
            var status = await _service.GetStatusById(id);
            if (status == null!)
                return NoContent();

            return Ok(status);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatus(int id, StatusUpdate model)
        {
            var status = await _service.UpdateStatus(id, model);
            if (status == null!)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var status = await _service.DeleteStatus(id);
            if (status == null!)
                return BadRequest("No status with the specified id was found and could not be deleted.");

            return NoContent();
        }
    }
}
