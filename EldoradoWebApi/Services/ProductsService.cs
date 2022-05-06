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

        public async Task<ProductObject> CreateProduct(ProductCreate model)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Name == model.Name);
            if (product == null)
            {
                await _context.AddAsync(new ProductEntity(model.Name, model.Description, model.Price, model.SubCategoryId, model.SizeId, model.BrandId, model.ColorId, model.StatusId));
                await _context.SaveChangesAsync();
            }
            return null!;
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
            var productName = await _context.Products.FirstOrDefaultAsync(x => x.Name == model.Name);

            if (product == null)
            {
                return null!;
            }

            if (productName == null)
            {
                product.Id = model.Id;
                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.SubCategoryId = model.SubCategoryId;
                product.SizeId = model.SizeId;
                product.BrandId = model.BrandId;
                product.ColorId = model.ColorId;
                product.StatusId = model.StatusId;
                product.CouponId = model.CouponId;

                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return new ProductObject(product.Id, product.Name, product.Description, product.Price);
            }
            return null!;
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
