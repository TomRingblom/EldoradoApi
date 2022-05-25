using EldoradoWebApi.Data;
using EldoradoWebApi.Models.Entities;
using EldoradoWebApi.Models.Sizes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace EldoradoWebApi.Services;

public class SizeService : ISizeService
{
    private readonly SqlContext _context;

    public SizeService(SqlContext context)
    {
        _context = context;
    }

    public async Task<SizeObject> CreateSize(SizeCreate model)
    {
        var size = await _context.Sizes.FirstOrDefaultAsync(x => x.Name == model.Name);
        if (size == null)
        {
            await _context.Sizes.AddAsync(new SizeEntity(model.Name));
            await _context.SaveChangesAsync();
        }
        else
            return null!;

        return new SizeObject(model.Name);
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
        return size == null ? null! : new SizeObject(size.Id, size.Name);
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