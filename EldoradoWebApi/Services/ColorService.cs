using EldoradoWebApi.Data;
using EldoradoWebApi.Models.Colors;
using EldoradoWebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EldoradoWebApi.Services
{
    public class ColorService : IColorService
    {
        private readonly SqlContext _context;

        public ColorService(SqlContext context)
        {
            _context = context;
        }
        public async Task<ColorObject> CreateColor(ColorCreate model)
        {
           var color = await _context.Colors.Where(x=> x.Name == model.Name).FirstOrDefaultAsync();
            if(color != null)
            {
                return null;
            }
            await _context.Colors.AddAsync(new ColorEntity(model.Name));
            await _context.SaveChangesAsync();

            return null!;
        }
        public async Task<IEnumerable<ColorObject>> GetColors()
        {
            var colors = new List<ColorObject>();
            foreach (var color in await _context.Colors.ToListAsync())
            {
                colors.Add(new ColorObject(color.Id,color.Name));
            }
            return colors;
        }
        public async Task<ColorObject> GetColorById(int id)
        {          
                var colorId = await _context.Colors.FirstOrDefaultAsync(x => x.Id == id);
                return new ColorObject(colorId.Id, colorId.Name);
       
        }

        public async Task<ColorObject> UpdateColor(int id, ColorUpdate model)
        {          
            var color = await _context.Colors.FindAsync(id);
            if (color == null)
                return null;

            color.Name = model.Name;
            var colorName = await _context.Colors.Where(x => x.Name == model.Name).FirstOrDefaultAsync();
            if (colorName != null)
            {
                return null;
            }

            _context.Entry(color).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new ColorObject(color.Id, color.Name);
        }
        public async Task<ColorObject> DeleteColor(int id)
        {
            var color = await _context.Colors.FirstOrDefaultAsync(y => y.Id == id);
            if(color == null)
            {
                return null!;
            }
            _context.Colors.Remove(color);
            await _context.SaveChangesAsync();
            return new ColorObject(color.Id,color.Name);
        }

    }
}
