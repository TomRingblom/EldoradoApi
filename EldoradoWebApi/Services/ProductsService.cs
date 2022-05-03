using EldoradoWebApi.Data;
using EldoradoWebApi.Models.Entities;
using EldoradoWebApi.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace EldoradoWebApi.Services
{
    public class ProductsService : IProductService
    {
        private readonly SqlContext _context;

        public ProductsService(SqlContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(ProductCreate model)
        {
            await _context.AddAsync(new ProductEntity(model.Name, model.Description, model.Price, model.SubCategoryId,model.SizeId, model.BrandId, model.ColorId, model.StatusId, model.CouponId));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductObject>> GetProducts()
        {
            var products = new List<ProductObject>();

            foreach (var product in await _context.Products.ToListAsync())
            {
                products.Add(new ProductObject(product.Id, product.Name, product.Description, product.Price));
            }

            return products;
        }

        public async Task<ProductObject> GetProductById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            return new ProductObject(product.Id, product.Name, product.Description, product.Price);
        }

        public async Task<ProductObject> UpdateProduct(int id, ProductUpdate model)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return null!;
            }

            product.Id = model.Id;

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return new ProductObject(product.Id, product.Name, product.Description, product.Price);
        }

        public async Task<ProductObject> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return null!;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return new ProductObject(product.Id, product.Name, product.Description, product.Price);
        }

        

        

        
    }
}
