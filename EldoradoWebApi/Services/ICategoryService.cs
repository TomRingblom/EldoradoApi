using EldoradoWebApi.Models.Categories;

namespace EldoradoWebApi.Services
{
    public interface ICategoryService
    {
        Task CreateCategory(CategoryCreate model);
        Task<IEnumerable<CategoryObject>> GetCategories();
        Task<CategoryObject> GetCategoryById(int id);
        Task<CategoryObject> UpdateCategory(int id, CategoryUpdate model);
        Task<CategoryObject> DeleteCategory(int id);
    }
}
