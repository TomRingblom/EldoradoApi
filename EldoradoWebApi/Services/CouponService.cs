using EldoradoWebApi.Data;
using EldoradoWebApi.Models.Coupons;
using EldoradoWebApi.Models.Entities;
using EldoradoWebApi.Models.Sizes;
using Microsoft.EntityFrameworkCore;

namespace EldoradoWebApi.Services;

public class CouponService : ICouponService
{
    private readonly SqlContext _context;

    public CouponService(SqlContext context)
    {
        _context = context;
    }

    public async Task<CouponObject> CreateCoupon(CouponCreate model)
    {
        var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.Discount == model.Discount);
        if (coupon == null)
        {
            await _context.Coupons.AddAsync(new CouponEntity(model.Discount));
            await _context.SaveChangesAsync();
        }
        else
            return null!;

        return new CouponObject(model.Discount);
    }

    public async Task<IEnumerable<CouponObject>> GetCoupons()
    {
        var coupons = new List<CouponObject>();
        foreach (var coupon in await _context.Coupons.ToListAsync())
        {
            coupons.Add(new CouponObject(coupon.Id, coupon.Discount));
        }
        return coupons;
    }

    public async Task<CouponObject> GetCouponById(int id)
    {
        var coupon = await _context.Coupons.FirstOrDefaultAsync(o => o.Id == id);
        return coupon == null ? null! : new CouponObject(coupon!.Id, coupon.Discount);
    }

    public async Task<CouponObject> UpdateCoupon(int id, CouponUpdate model)
    {
        var coupon = await _context.Coupons.FindAsync(id);
        if (coupon == null)
            return null!;

        coupon.Discount = model.Discount;

        _context.Entry(coupon).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return new CouponObject(coupon.Id, coupon.Discount);
    }

    public async Task<CouponObject> DeleteCoupon(int id)
    {
        var coupon = await _context.Coupons.FirstOrDefaultAsync(o => o.Id == id);
        if (coupon == null)
            return null!;

        _context.Coupons.Remove(coupon);
        await _context.SaveChangesAsync();
        return new CouponObject(coupon.Id, coupon.Discount);
    }
}