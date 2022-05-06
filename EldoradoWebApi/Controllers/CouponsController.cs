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
            if (!ModelState.IsValid) return BadRequest();
            var coupon = await _service.CreateCoupon(model);
            return coupon == null! ? BadRequest("A Coupon with the same discount already exists") : Created("Coupon created successfully.", null);
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
            return coupon == null! ? NoContent() : Ok(coupon);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoupon(int id, CouponUpdate model)
        {
            return await _service.UpdateCoupon(id, model) == null! ? BadRequest() : NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            return await _service.DeleteCoupon(id) == null! ? BadRequest("No coupon with the given id was found and could not be deleted.") : NoContent();
        }
    }
}
