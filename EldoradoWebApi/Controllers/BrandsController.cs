﻿using EldoradoWebApi.Models.Brands;
using EldoradoWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EldoradoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _service;

        public BrandsController(IBrandService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSize(BrandCreate model)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateBrand(model);
                return Created("Size created successfully.", null);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetSizes()
        {
            return Ok(await _service.GetBrands());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSize(int id)
        {
            var brand = await _service.GetBrandById(id);
            if (brand == null)
                return NoContent();

            return Ok(brand);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSize(int id, BrandUpdate model)
        {
            var brand = await _service.UpdateBrand(id, model);
            if (brand == null)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var brand = await _service.DeleteBrand(id);
            if (brand == null)
                return BadRequest("No size with the specified id was found and could not be deleted.");

            return NoContent();
        }
    }
}
