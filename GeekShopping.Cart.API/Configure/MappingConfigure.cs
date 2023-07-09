using AutoMapper;
using GeekShopping.Cart.API.Data.ValueObjects;
using GeekShopping.Cart.API.Models;
using GeekShopping.Cart.Data.ValueObjects.Models;

namespace GeekShopping.Cart.API.Configure
{
    public class MappingConfigure
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, ProductEntity>().ReverseMap();
                config.CreateMap<CartHeaderVO, CartHeaderEntity>().ReverseMap();
                config.CreateMap<CartDetailVO, CartDetailEntity>().ReverseMap();
                config.CreateMap<CartVO, GeekShopping.Cart.API.Models.Cart>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
