using EldoradoWebApi.Models.Brands;

namespace EldoradoWebApi.Services
{
    public interface IBrandService
    {

        Task CreateBrand(BrandCreate model);
        Task<IEnumerable<BrandObject>> GetBrands();
        Task<BrandObject> GetBrandById(int id);
        Task<BrandObject> UpdateBrand(int id, BrandUpdate model);
        Task<BrandObject> DeleteBrand(int id);
    }
}
