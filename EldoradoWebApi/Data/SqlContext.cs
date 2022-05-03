using EldoradoApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EldoradoApi.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
                
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }
        public virtual DbSet<BrandEntity> Brands { get; set; } = null!;
        public virtual DbSet<ColorEntity> Colors { get; set; } = null!;
        public virtual DbSet<CouponEntity> Coupons { get; set; } = null!;
        public virtual DbSet<OrderDetailsEntity> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderEntity> Orders { get; set; } = null!;
        public virtual DbSet<ProductEntity> Products { get; set; } = null!;
        public virtual DbSet<SizeEntity> Sizes { get; set; } = null!;
        public virtual DbSet<StatusEntity> Statuses { get; set; } = null!;
    }
}
