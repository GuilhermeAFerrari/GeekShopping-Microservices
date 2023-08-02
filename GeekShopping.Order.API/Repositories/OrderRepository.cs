using GeekShopping.Order.API.Models;
using GeekShopping.Order.API.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Order.API.Repositories
{
    public class OrderRepository
    {
        private readonly DbContextOptions<SqlServerContext> _context;

        public OrderRepository(DbContextOptions<SqlServerContext> context)
        {
            _context = context;
        }

        public async Task<bool> AddOrder(OrderHeaderEntity header)
        {
            if (header is null) return false;

            await using var _db = new SqlServerContext(_context);
            _db.OrderHeaders.Add(header);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task UpdateOrderPaymentStatus(long orderHeaderId, bool status)
        {
            await using var _db = new SqlServerContext(_context);
            var header = await _db.OrderHeaders.FirstOrDefaultAsync(o => o.Id == orderHeaderId);

            if (header is not null)
            {
                header.PaymentStatus = status;
                await _db.SaveChangesAsync();
            };
        }
    }
}
