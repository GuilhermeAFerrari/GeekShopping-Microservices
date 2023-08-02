using GeekShopping.Order.API.Models;

namespace GeekShopping.Order.API.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeaderEntity header);
        Task UpdateOrderPaymentStatus(long orderHeaderId, bool paid);
    }
}
