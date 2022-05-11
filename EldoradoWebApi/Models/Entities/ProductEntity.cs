using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EldoradoWebApi.Models.Entities
{
    public class ProductEntity
    {
        public ProductEntity()
        {

        }

        public ProductEntity(string name, string description, double price, int subCategoryId, int sizeId, int brandId, int colorId, int statusId, List<TagEntity> tags)
        {
            Name = name;
            Description = description;
            Price = price;
            SubCategoryId = subCategoryId;
            SizeId = sizeId;
            BrandId = brandId;
            ColorId = colorId;
            StatusId = statusId;
            Tags = tags;
        }

        public ProductEntity(string name, string description, double price, int subCategoryId, int sizeId, int brandId, int colorId, int statusId, int? couponId)
        {
            Name = name;
            Description = description;
            Price = price;
            SubCategoryId = subCategoryId;
            SizeId = sizeId;
            BrandId = brandId;
            ColorId = colorId;
            StatusId = statusId;
            CouponId = couponId;
        }

        public ProductEntity(int id, string name, string description, double price, int subCategoryId, int sizeId, int brandId, int colorId, int statusId, int? couponId)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            SubCategoryId = subCategoryId;
            SizeId = sizeId;
            BrandId = brandId;
            ColorId = colorId;
            StatusId = statusId;
            CouponId = couponId;
        }





        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; } = null!;
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; } = null!;
        [Required]
        [Column(TypeName = "money")]
        public double Price { get; set; }

        [Required]
        public int SubCategoryId { get; set; }
        public SubCategoryEntity SubCategory { get; set; } = null!;

        [Required]
        public int SizeId { get; set; }
        public SizeEntity Size { get; set; } = null!;

        [Required]
        public int BrandId { get; set; }
        public BrandEntity Brand { get; set; } = null!;

        [Required]
        public int ColorId { get; set; }
        public ColorEntity Color { get; set; } = null!;

        [Required]
        public int StatusId { get; set; }
        public StatusEntity Status { get; set; } = null!;

        public int? CouponId { get; set; }
        public CouponEntity Coupon { get; set; } = null!;

        public ICollection<TagEntity> Tags { get; set; }

    }
}