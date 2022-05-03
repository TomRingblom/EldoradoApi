using EldoradoWebApi.Models.Entities;

namespace EldoradoWebApi.Models.Products
{
    public class ProductObject
    {
        public ProductObject(int id, string name, string description, double price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public ProductObject(string name, string description, double price, string subCategoryName, string sizeName, string brandName, string colorName, string statusName, int discountCoupon)
        {
            Name = name;
            Description = description;
            Price = price;
            SubCategoryName = subCategoryName;
            SizeName = sizeName;
            BrandName = brandName;
            ColorName = colorName;
            StatusName = statusName;
            DiscountCoupon = discountCoupon;
        }

        public ProductObject(int id, string name, string description, double price, string subCategoryName, string sizeName, string brandName, string colorName, string statusName, int discountCoupon)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            SubCategoryName = subCategoryName;
            SizeName = sizeName;
            BrandName = brandName;
            ColorName = colorName;
            StatusName = statusName;
            DiscountCoupon = discountCoupon;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }
        public string SubCategoryName { get; set; } = null!;
        public string SizeName { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public string ColorName { get; set; } = null!;
        public string StatusName { get; set; } = null!;
        public int DiscountCoupon { get; set; }
    }
}
