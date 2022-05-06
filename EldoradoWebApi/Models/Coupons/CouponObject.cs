namespace EldoradoWebApi.Models.Coupons;

public class CouponObject
{
    public CouponObject()
    {

    }

    public CouponObject(int discount)
    {
        Discount = discount;
    }

    public CouponObject(int id, int discount)
    {
        Id = id;
        Discount = discount;
    }

    public int Id { get; set; }
    public int Discount { get; set; }
}