using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EldoradoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategory _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderCreate model)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateOrder(model);
                return Created("Order created successfully.", null);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await _service.GetOrders());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _service.GetOrderById(id);
            if (order == null)
                return NoContent();

            return Ok(order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderUpdate model)
        {
            var order = await _service.UpdateOrder(id, model);
            if (order == null)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _service.DeleteOrder(id);
            if (order == null)
                return BadRequest("No order with the specified id was found and could not be deleted.");

            return NoContent();
        }
    }
}




//Brand
//Color
//Coupon
//Status