using EldoradoWebApi.Models.Products;

namespace EldoradoWebApi.Services
{
    public interface IProductService
    {
        Task<ProductObject> CreateProduct(ProductCreate model);
        Task<IEnumerable<ProductObject>> GetProducts();
        Task<ProductObject> GetProductById(int id);
        Task<ProductObject> UpdateProduct(int id, ProductUpdate model);
        Task<ProductObject> DeleteProduct(int id);
    }
}
