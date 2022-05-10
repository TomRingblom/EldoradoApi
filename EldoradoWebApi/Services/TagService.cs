using EldoradoWebApi.Data;
using EldoradoWebApi.Models.Entities;
using EldoradoWebApi.Models.Sizes;
using EldoradoWebApi.Models.Tags;
using Microsoft.EntityFrameworkCore;

namespace EldoradoWebApi.Services;

public class TagService : ITagService
{
    private readonly SqlContext _context;

    public TagService(SqlContext context)
    {
        _context = context;
    }

    public async Task<TagObject> CreateTag(TagCreate model)
    {
        var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Name == model.Name);
        if (tag == null)
        {
            await _context.Tags.AddAsync(new TagEntity(model.Name));
            await _context.SaveChangesAsync();
        }
        else
            return null!;

        return new TagObject(model.Name);
    }

    public async Task<IEnumerable<TagObject>> GetTags()
    {
        var tags = new List<TagObject>();
        foreach (var tag in await _context.Tags.ToListAsync())
        {
            tags.Add(new TagObject(tag.Id, tag.Name));
        }
        return tags;
    }

    public async Task<TagObject> GetTagById(int id)
    {
        var tag = await _context.Tags.FirstOrDefaultAsync(o => o.Id == id);
        return tag == null ? null! : new TagObject(tag.Id, tag.Name);
    }

    public async Task<TagObject> UpdateTag(int id, TagUpdate model)
    {
        var tag = await _context.Tags.FindAsync(id);
        if (tag == null)
            return null!;

        tag.Name = model.Name;

        _context.Entry(tag).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return new TagObject(tag.Id, tag.Name);
    }

    public async Task<TagObject> DeleteTag(int id)
    {
        var tag = await _context.Tags.FirstOrDefaultAsync(o => o.Id == id);
        if (tag == null)
            return null!;

        _context.Tags.Remove(tag);
        await _context.SaveChangesAsync();
        return new TagObject(tag.Id, tag.Name);
    }
}