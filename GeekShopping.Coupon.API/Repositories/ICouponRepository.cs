using GeekShopping.Coupon.API.Data.ValueObjects;

namespace GeekShopping.Coupon.API.Repositories
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCouponByCouponCode(string couponCode);
    }
}
