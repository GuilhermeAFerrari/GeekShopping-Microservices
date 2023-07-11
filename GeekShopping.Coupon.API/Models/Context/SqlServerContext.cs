using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Coupon.API.Models.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext() { }

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        public DbSet<CouponEntity> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CouponEntity>().HasData(new CouponEntity
            {
                Id = 1,
                CouponCode = "ERUDIO_2022_10",
                DiscountAmount = 10
            });
            modelBuilder.Entity<CouponEntity>().HasData(new CouponEntity
            {
                Id = 2,
                CouponCode = "ERUDIO_2022_15",
                DiscountAmount = 15
            });
        }
    }
}
