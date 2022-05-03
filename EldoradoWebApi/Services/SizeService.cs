using EldoradoApi.Data;
using EldoradoApi.Models.Entities;
using EldoradoApi.Models.Sizes;
using Microsoft.EntityFrameworkCore;

namespace EldoradoApi.Services;

public class SizeService : ISizeService
{
    private readonly SqlContext _context;

    public SizeService(SqlContext context)
    {
        _context = context;
    }

    public async Task CreateSize(SizeCreate model)
    {
        await _context.Sizes.AddAsync(new SizeEntity(model.Name));
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<SizeObject>> GetSizes()
    {
        var sizes = new List<SizeObject>();
        foreach (var size in await _context.Sizes.ToListAsync())
        {
            sizes.Add(new SizeObject(size.Id, size.Name));
        }
        return sizes;
    }

    public async Task<SizeObject> GetSizeById(int id)
    {
        var size = await _context.Sizes.FirstOrDefaultAsync(o => o.Id == id);
        return new SizeObject(size.Id, size.Name);
    }

    public async Task<SizeObject> UpdateSize(int id, SizeUpdate model)
    {
        var size = await _context.Sizes.FindAsync(id);
        if (size == null)
            return null!;

        size.Name = model.Name;

        _context.Entry(size).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return new SizeObject(size.Id, size.Name);
    }

    public async Task<SizeObject> DeleteSize(int id)
    {
        var size = await _context.Sizes.FirstOrDefaultAsync(o => o.Id == id);
        if (size == null)
            return null!;

        _context.Sizes.Remove(size);
        await _context.SaveChangesAsync();
        return new SizeObject(size.Id, size.Name);
    }
}