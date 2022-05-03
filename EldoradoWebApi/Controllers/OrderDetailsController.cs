using EldoradoWebApi.Models.OrderDetails;
using EldoradoWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EldoradoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _service;

        public OrderDetailsController(IOrderDetailsService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDetails(OrderDetailsCreate model)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateDetails(model);
                return Created("OrderDetails added", null);
            }
            return BadRequest();
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var orderDetails = await _service.GetDetails(id);
            if (orderDetails == null)
                return NoContent();

            return Ok(orderDetails);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDetails(int id, OrderDetailsUpdate model)
        {
            var order = await _service.UpdateDetails(id, model);
            if (order == null)
                return BadRequest();

            return NoContent();
        }

    }
}
