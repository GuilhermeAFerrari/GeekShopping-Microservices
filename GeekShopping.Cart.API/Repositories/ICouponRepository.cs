using GeekShopping.Cart.API.Data.ValueObjects;

namespace GeekShopping.Cart.API.Repositories
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCoupon(string couponCode, string token);
    }
}
