using GeekShopping.Product.API.Data.ValueObjects;

namespace GeekShopping.Product.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> FindAllAsync();
        Task<ProductVO> FindByIdAsync(long id);
        Task<ProductVO> CreateAsync(ProductVO product);
        Task<ProductVO> UpdateAsync(ProductVO product);
        Task<bool> DeleteByIdAsync(long id);
    }
}
