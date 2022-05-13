using EldoradoWebApi.Models.Tags;
using EldoradoWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EldoradoWebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TagsController : Controller
{
    private readonly ITagService _service;

    public TagsController(ITagService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTag(TagCreate model)
    {
        if (!ModelState.IsValid) return BadRequest();
        var tag = await _service.CreateTag(model);
        return tag == null! ? BadRequest($"A tag with the given name already exists.") : Created("Tag created successfully!", model);
    }

    [HttpGet]
    public async Task<IActionResult> GetTags()
    {
        return Ok(await _service.GetTags());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTag(int id)
    {
        var tag = await _service.GetTagById(id);
        return tag == null! ? NotFound() : Ok(tag);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTag(int id, TagUpdate model)
    {
        return await _service.UpdateTag(id, model) == null! ? BadRequest() : NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTag(int id)
    {
        return await _service.DeleteTag(id) == null! ? BadRequest("No tag with the given id was found and could not be deleted.") : NoContent();
    }
}