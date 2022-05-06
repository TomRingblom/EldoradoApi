using EldoradoWebApi.Data;
using EldoradoWebApi.Models.Brands;
using EldoradoWebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EldoradoWebApi.Services
{
    public class BrandService : IBrandService
    {
        private readonly SqlContext _context;

        public BrandService(SqlContext context)
        {
            _context = context;
        }
        public async Task<BrandObject> CreateBrand(BrandCreate model)
        {
            var brand = await _context.Brands.Where(x => x.Name == model.Name).FirstOrDefaultAsync();
            if (brand != null)
            {
                return null;
            }
            await _context.Brands.AddAsync(new BrandEntity(model.Name));
            await _context.SaveChangesAsync();
            return new BrandObject(model.Name);
        }
        public async Task<IEnumerable<BrandObject>> GetBrands()
        {
            var brands = new List<BrandObject>();
            foreach (var brand in await _context.Brands.ToListAsync())
            {
                brands.Add(new BrandObject(brand.Id, brand.Name));
            }
            return brands;
        }

        public async Task<BrandObject> GetBrandById(int id)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(o => o.Id == id);
            return new BrandObject(brand.Id, brand.Name);
        }

        public async Task<BrandObject> UpdateBrand(int id, BrandUpdate model)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
                return null!;

            brand.Name = model.Name;
            var brandName = await _context.Brands.Where(x => x.Name == model.Name).FirstOrDefaultAsync();
            if (brandName != null)
            {
                return null;
            }
            _context.Entry(brand).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new BrandObject(brand.Id, brand.Name);
        }
        public async Task<BrandObject> DeleteBrand(int id)
        {
            var brand = await _context.Brands.FirstOrDefaultAsync(o => o.Id == id);
            if (brand == null)
                return null!;

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            return new BrandObject(brand.Id, brand.Name);
        }

    }
}
