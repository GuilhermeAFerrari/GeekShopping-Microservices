using AutoMapper;
using GeekShopping.Coupon.API.Data.ValueObjects;
using GeekShopping.Coupon.API.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Coupon.API.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly SqlServerContext _context;
        private IMapper _mapper;

        public CouponRepository(SqlServerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CouponVO> GetCouponByCouponCode(string couponCode)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.CouponCode == couponCode);
            return _mapper.Map<CouponVO>(coupon);
        }
    }
}
