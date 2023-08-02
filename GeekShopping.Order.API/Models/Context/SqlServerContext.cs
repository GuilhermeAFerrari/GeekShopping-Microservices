using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Order.API.Models.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        public DbSet<OrderDetailEntity> OrderDetails { get; set; }
        public DbSet<OrderHeaderEntity> OrderHeaders { get; set; }
    }
}