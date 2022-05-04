using EldoradoWebApi.Data;
using EldoradoWebApi.Models.Categories;
using EldoradoWebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EldoradoWebApi.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly SqlContext _context;

        public CategoryService(SqlContext context)
        {
            _context = context;
        }

        public async Task CreateCategory(CategoryCreate model)
        {
            await _context.Categories.AddAsync(new CategoryEntity(model.Name));
            await _context.SaveChangesAsync();
            
        }



        public async Task<IEnumerable<CategoryObject>> GetCategories()
        {
            var categoryList = new List<CategoryObject>();
            foreach (var category in await _context.Categories.ToListAsync())
            {
                categoryList.Add(new CategoryObject(category.Name));
            }
            return categoryList;
        }

        public async Task<CategoryObject> GetCategoryById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return new CategoryObject(category.Name);
        }

        public async Task<CategoryObject> UpdateCategory(int id, CategoryUpdate model)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return null!;

            category.Id = model.Id;
           

            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new CategoryObject(category.Name);
        }

        public async Task<CategoryObject> DeleteCategory(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(o => o.Id == id);
            if (category == null)
                return null!;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return new CategoryObject(category.Name);
        }
    }
}
