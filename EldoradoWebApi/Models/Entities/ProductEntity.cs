using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EldoradoApi.Models.Entities
{
    public class ProductEntity
    {

        public ProductEntity()
        {

        }

        public ProductEntity(int id)
        {
            Id = id;
        }

        public ProductEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public ProductEntity(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public ProductEntity(int id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        public ProductEntity(int id, string name, string description, decimal price, int sizeId, int brandId, int colorId, int statusId, int? couponId)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
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
        public decimal Price { get; set; }

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
    }
}