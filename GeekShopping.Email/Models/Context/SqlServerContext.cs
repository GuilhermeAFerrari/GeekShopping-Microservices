using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Email.Models.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        public DbSet<EmailLog> Logs { get; set; }
    }
}