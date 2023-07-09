using AutoMapper;

namespace GeekShopping.Cart.API.Configure
{
    public class MappingConfigure
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                //config.CreateMap<ProductVO, ProductEntity>();
                //config.CreateMap<ProductEntity, ProductVO>();
            });

            return mappingConfig;
        }
    }
}
