using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllAsync();
        Task<ProductModel> FindByIdAsync(long id);
        Task<ProductModel> CreateAsync(ProductModel model);
        Task<ProductModel> UpdateAsync(ProductModel model);
        Task<bool> DeleteByIdAsync(long id);
    }
}
