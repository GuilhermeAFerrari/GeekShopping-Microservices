using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Product.API.Models.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext() {}

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
