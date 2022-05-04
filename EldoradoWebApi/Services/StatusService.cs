using EldoradoWebApi.Data;
using EldoradoWebApi.Models.Entities;
using EldoradoWebApi.Models.Statuses;
using Microsoft.EntityFrameworkCore;

namespace EldoradoWebApi.Services;

public class StatusService : IStatusService
{
    private readonly SqlContext _context;

    public StatusService(SqlContext context)
    {
        _context = context;
    }

    public async Task CreateStatus(StatusCreate model)
    {
        await _context.Statuses.AddAsync(new StatusEntity(model.Name));
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<StatusObject>> GetStatuses()
    {
        var statuses = new List<StatusObject>();
        foreach (var status in await _context.Statuses.ToListAsync())
        {
            statuses.Add(new StatusObject(status.Id, status.Name));
        }
        return statuses;
    }

    public async Task<StatusObject> GetStatusById(int id)
    {
        var status = await _context.Statuses.FirstOrDefaultAsync(o => o.Id == id);
        return new StatusObject(status.Id, status.Name);
    }

    public async Task<StatusObject> UpdateStatus(int id, StatusUpdate model)
    {
        var status = await _context.Sizes.FindAsync(id);
        if (status == null)
            return null!;

        status.Name = model.Name;

        _context.Entry(status).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return new StatusObject(status.Id, status.Name);
    }

    public async Task<StatusObject> DeleteStatus(int id)
    {
        var status = await _context.Statuses.FirstOrDefaultAsync(o => o.Id == id);
        if (status == null)
            return null!;

        _context.Statuses.Remove(status);
        await _context.SaveChangesAsync();
        return new StatusObject(status.Id, status.Name);
    }
}