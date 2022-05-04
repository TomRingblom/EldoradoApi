using EldoradoWebApi.Models.Categories;

namespace EldoradoWebApi.Services
{
    public interface ISubCategoryService
    {
        Task CreateSubCategory(SubCategoryCreate model);
        Task<IEnumerable<SubCategoryObject>> GetSubCategories();
        Task<SubCategoryObject> GetSubCategoryById(int id);
        Task<SubCategoryObject> UpdateSubCategory(int id, SubCategoryUpdate model);
        Task<SubCategoryObject> DeleteSubCategory(int id);
    }
}
