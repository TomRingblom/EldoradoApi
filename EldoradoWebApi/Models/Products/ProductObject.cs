using EldoradoWebApi.Models.Entities;
using EldoradoWebApi.Models.Tags;

namespace EldoradoWebApi.Models.Products
{
    public class ProductObject
    {
        public ProductObject()
        {
            
        }

        public ProductObject(string name)
        {
            Name = name;
        }

        public ProductObject(int id, string name, string description, double price, string categoryName, string subCategoryName, string sizeName, string brandName, string colorName, List<string> tagNames, string statusName)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CategoryName = categoryName;
            SubCategoryName = subCategoryName;
            SizeName = sizeName;
            BrandName = brandName;
            ColorName = colorName;
            TagNames = tagNames;
            StatusName = statusName;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }
        public string CategoryName { get; set; } = null!;
        public string SubCategoryName { get; set; } = null!;
        public string SizeName { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public string ColorName { get; set; } = null!;
        public string StatusName { get; set; } = null!;
        public List<string> TagNames { get; set; }
        public int DiscountCoupon { get; set; }
    }
}
