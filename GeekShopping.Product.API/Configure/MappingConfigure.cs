using AutoMapper;
using GeekShopping.Product.API.Data.ValueObjects;

namespace GeekShopping.Product.API.Configure
{
    public class MappingConfigure
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, ModelsProduct>();
                config.CreateMap<ProductVO, Models.Product>();
            });

            return mappingConfig;
        }
    }
}
