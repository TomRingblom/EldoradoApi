using EldoradoWebApi.Models.Addresses;
using EldoradoWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EldoradoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(AddressCreate model)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAddress(model);
                return Created("Address created successfully.", model);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress(int id)
        {
            return new OkObjectResult(await _service.GetAddressById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var addresses = await _service.GetAddresses();
            if (addresses == null)
                return NoContent();
            
            return new OkObjectResult(addresses);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, AddressUpdate model)
        {
            var order = await _service.UpdateAddress(id, model);
            if (order == null)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var order = await _service.DeleteAddress(id);
            if (order == null)
                return BadRequest("No Address with the specified id was found and could not be deleted.");

            return NoContent();
        }
    }
}
