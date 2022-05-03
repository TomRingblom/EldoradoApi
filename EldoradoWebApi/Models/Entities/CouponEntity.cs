using System.ComponentModel.DataAnnotations;

namespace EldoradoWebApi.Models.Entities
{
    public class CouponEntity
    {
        public CouponEntity()
        {
        }

        public CouponEntity(int id, int discount)
        {
            Id = id;
            Discount = discount;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public int Discount { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; } = null!;
    }
}