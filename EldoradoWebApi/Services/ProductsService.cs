using EldoradoWebApi.Data;
using EldoradoWebApi.Models.Entities;
using EldoradoWebApi.Models.Products;
using EldoradoWebApi.Models.Tags;
using Microsoft.EntityFrameworkCore;

namespace EldoradoWebApi.Services
{
    public class ProductsService : IProductService
    {
        private readonly SqlContext _context;
        private readonly ITagService _tagService;

        public ProductsService(SqlContext context)
        {
            _context = context;
        }

        public async Task<ProductObject> CreateProduct(ProductCreate model)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Name == model.Name);
            List<TagEntity> tags = new List<TagEntity>();
            foreach (var tag in model.TagNames)
            {
               
                var result = await _context.Tags.ToListAsync();
                var tagEntity = result.Find(x => x.Name == tag);

                if ( tagEntity != null)
                {
                    tags.Add(tagEntity);
                }
                else
                {
                  TagCreate tagCreate = new TagCreate(tag);
                  var newEntity = await _tagService.CreateTag(tagCreate);

                    var newTag = await _context.Tags.FirstOrDefaultAsync(x => x.Name == newEntity.Name);

                    tags.Add(newTag);
                }


            }
            if (product == null)
            {
                await _context.AddAsync(new ProductEntity(
                    model.Name, 
                    model.Description, 
                    model.Price, 
                    model.SubCategoryId, 
                    model.SizeId, 
                    model.BrandId, 
                    model.ColorId, 
                    model.StatusId,
                    tags
                    
                    ));
                await _context.SaveChangesAsync();
            }
            return new ProductObject(model.Name);
        }

        public async Task<IEnumerable<ProductObject>> GetProducts()
        {
            var products = new List<ProductObject>();

            foreach (var product in await _context.Products.
                         Include(x => x.SubCategory).
                         ThenInclude(x => x.Category).
                         Include(x => x.Size).
                         Include(x => x.Brand).
                         Include(x => x.Color).
                         Include(x => x.Status).
                         Include(x => x.Tags).
                         ToListAsync())
            {
                var tags = product.Tags.Select(tag => tag.Name).ToList();
                products.Add(new ProductObject(
                    product.Id, 
                    product.Name, 
                    product.Description, 
                    product.Price, 
                    product.SubCategory.Category.Name, 
                    product.SubCategory.Name, 
                    product.Size.Name, 
                    product.Brand.Name, 
                    product.Color.Name,
                    tags,
                    product.Status.Name));
            }

            return products;
        }

        public async Task<ProductObject> GetProductById(int id)
        {
            var product = await _context.Products.
                Include(x => x.SubCategory).
                ThenInclude(x => x.Category).
                Include(x => x.Size).
                Include(x => x.Brand).
                Include(x => x.Color).
                Include(x => x.Status).
                Include(x => x.Tags).
                FirstOrDefaultAsync(p => p.Id == id);

            var tags = product.Tags.Select(tag => tag.Name).ToList();
            return new ProductObject(
                product.Id, 
                product.Name, 
                product.Description, 
                product.Price, 
                product.SubCategory.Category.Name, 
                product.SubCategory.Name, 
                product.Size.Name, 
                product.Brand.Name, 
                product.Color.Name,
                tags,
                product.Status.Name);
        }

        public async Task<ProductObject> UpdateProduct(int id, ProductUpdate model)
        {
            var product = await _context.Products.FindAsync(id);
            //var productName = await _context.Products.FirstOrDefaultAsync(x => x.Name == model.Name);
            List<TagEntity> tags = new List<TagEntity>();

            if ( product == null)
            {
                return null!;
            }

           else
            {
                var result = await _context.Tags.ToListAsync();
                foreach (var name in model.TagNames)
                {
                    var tagEntity = result.Find(x => x.Name == name);

                    tags.Add(tagEntity);
                }
                product.Id = id;
                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.SubCategoryId = model.SubCategoryId;
                product.SizeId = model.SizeId;
                product.BrandId = model.BrandId;
                product.ColorId = model.ColorId;
                product.StatusId = model.StatusId;
                product.Tags = tags;
                product.CouponId = model.CouponId;


                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                
                return new ProductObject(product.Name);
            }
          
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

            return new ProductObject(product.Name);
        }
    }
}
