using AutoMapper;
using GeekShopping.Coupon.API.Data.ValueObjects;
using GeekShopping.Coupon.API.Models;

namespace GeekShopping.Coupon.API.Configure
{
    public class MappingConfigure
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponVO, CouponEntity>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
