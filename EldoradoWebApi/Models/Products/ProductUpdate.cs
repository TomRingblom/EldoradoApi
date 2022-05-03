namespace EldoradoWebApi.Models.Products
{
    public class ProductUpdate
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }
        public int SubCategoryId { get; set; }
        public int SizeId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int StatusId { get; set; }
        public int CouponId { get; set; }
    }
}
