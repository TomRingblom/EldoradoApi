using EldoradoWebApi.Models.Coupons;
using EldoradoWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EldoradoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponService _service;
        public CouponsController(ICouponService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CouponCreate model)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateCoupon(model);
                return Created("Coupon created successfully.", null);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetCoupons()
        {
            return Ok(await _service.GetCoupons());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoupon(int id)
        {
            var coupon = await _service.GetCouponById(id);
            if (coupon == null)
                return NoContent();

            return Ok(coupon);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoupon(int id, CouponUpdate model)
        {
            var coupon = await _service.UpdateCoupon(id, model);
            if (coupon == null!)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            var coupon = await _service.DeleteCoupon(id);
            if (coupon == null)
                return BadRequest("No coupon with the specified id was found and could not be deleted.");

            return NoContent();
        }
    }
}
