using GeekShopping.Cart.API.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.Cart.API.Models
{
    [Table("cart_detail")]
    public class CartDetailEntity : BaseEntity
    {
        public long CartHeaderId { get; set; }

        [ForeignKey("CartHeaderId")]
        public virtual CartHeaderEntity CartHeader { get; set; } = null!;

        public long ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual ProductEntity Product { get; set; } = null!;

        [Column("count")]
        public int Count { get; set; }
    }
}
