using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> FindAllAsync(string token);
        Task<ProductViewModel> FindByIdAsync(long id, string token);
        Task<ProductViewModel> CreateAsync(ProductViewModel model, string token);
        Task<ProductViewModel> UpdateAsync(ProductViewModel model, string token);
        Task<bool> DeleteByIdAsync(long id, string token);
    }
}
