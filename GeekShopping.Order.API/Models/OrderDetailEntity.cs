using GeekShopping.Order.API.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.Order.API.Models
{
    [Table("order_detail")]
    public class OrderDetailEntity : BaseEntity
    {
        public long OrderHeaderId { get; set; }

        [ForeignKey("OrderHeaderId")]
        public virtual OrderHeaderEntity OrderHeader { get; set; } = null!;

        [Column("ProductId")]
        public long ProductId { get; set; }

        [Column("count")]
        public int Count { get; set; }

        [Column("product_name")]
        public string? ProductName { get; set; }

        [Column("price")]
        public decimal Price { get; set; }
    }
}