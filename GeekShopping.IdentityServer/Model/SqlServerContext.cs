using Microsoft.EntityFrameworkCore;

namespace GeekShopping.IdentityServer.Model
{
    public class Context : DbContext
    {
        public SqlServerContext() { }

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
