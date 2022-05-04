using EldoradoWebApi.Data;
using EldoradoWebApi.Models.Categories;
using EldoradoWebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EldoradoWebApi.Services
{
    public class SubCategoryService:ISubCategoryService
    {
        private readonly SqlContext _context;

        public SubCategoryService(SqlContext context)
        {
            _context = context;
        }

        public async Task CreateSubCategory(SubCategoryCreate model)
        {
            await _context.SubCategories.AddAsync(new SubCategoryEntity(model.Name, model.CategoryId));
            await _context.SaveChangesAsync();
        }

        public async Task<SubCategoryObject> DeleteSubCategory(int id)
        {
            var category = await _context.SubCategories.FirstOrDefaultAsync(o => o.Id == id);
            if (category == null)
                return null!;

            _context.SubCategories.Remove(category);
            await _context.SaveChangesAsync();
            return new SubCategoryObject(category.Name);
        }

        public async Task<IEnumerable<SubCategoryObject>> GetSubCategories()
        {
            var subCategoryList = new List<SubCategoryObject>();
            foreach (var category in await _context.SubCategories.ToListAsync())
            {
               subCategoryList.Add(new SubCategoryObject(category.Name));
            }
            return subCategoryList;
        }

        public async Task<SubCategoryObject> GetSubCategoryById(int id)
        {
            var category = await _context.SubCategories.FirstOrDefaultAsync(c => c.Id == id);
            return new SubCategoryObject(category.Name);
        }

        public async Task<SubCategoryObject> UpdateSubCategory(int id, SubCategoryUpdate model)
        {
            var category = await _context.SubCategories.FindAsync(id);
            if (category == null)
                return null!;

            category.Id = model.Id;


            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new SubCategoryObject(category.Name);
        }
    }
}
