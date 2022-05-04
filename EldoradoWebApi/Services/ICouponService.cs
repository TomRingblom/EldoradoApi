using EldoradoWebApi.Models.Coupons;

namespace EldoradoWebApi.Services;

public interface ICouponService
{
    Task CreateCoupon(CouponCreate model);
    Task<IEnumerable<CouponObject>> GetCoupons();
    Task<CouponObject> GetCouponById(int id);
    Task<CouponObject> UpdateCoupon(int id, CouponUpdate model);
    Task<CouponObject> DeleteCoupon(int id);
}