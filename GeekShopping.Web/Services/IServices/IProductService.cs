using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllAsync(string token);
        Task<ProductModel> FindByIdAsync(long id, string token);
        Task<ProductModel> CreateAsync(ProductModel model, string token);
        Task<ProductModel> UpdateAsync(ProductModel model, string token);
        Task<bool> DeleteByIdAsync(long id, string token);
    }
}
