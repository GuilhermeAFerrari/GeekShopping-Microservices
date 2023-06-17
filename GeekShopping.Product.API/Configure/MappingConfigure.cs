using AutoMapper;
using GeekShopping.Product.API.Data.ValueObjects;
using GeekShopping.Product.API.Models;

namespace GeekShopping.Product.API.Configure
{
    public class MappingConfigure
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, ProductEntity>();
                config.CreateMap<ProductVO, ProductEntity>();
            });

            return mappingConfig;
        }
    }
}
