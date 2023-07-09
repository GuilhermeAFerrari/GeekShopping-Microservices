using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Cart.API.Models.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CartDetailEntity> CartDetails { get; set; }
        public DbSet<CartHeaderEntity> CartHeaders { get; set; }
    }
}
