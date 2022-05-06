using EldoradoWebApi.Models.Categories;

namespace EldoradoWebApi.Services
{
    public interface ISubCategoryService
    {
        Task<SubCategoryObject> CreateSubCategory(SubCategoryCreate model);
        Task<IEnumerable<SubCategoryObject>> GetSubCategories();
        Task<SubCategoryObject> GetSubCategoryById(int id);
        Task<SubCategoryObject> UpdateSubCategory(int id, SubCategoryUpdate model);
        Task<SubCategoryObject> DeleteSubCategory(int id);
    }
}
