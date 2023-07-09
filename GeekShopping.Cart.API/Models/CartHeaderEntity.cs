using GeekShopping.Cart.API.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.Cart.API.Models
{
    [Table("cart_header")]
    public class CartHeaderEntity : BaseEntity
    {
        [Column("user_id")]
        public string UserId { get; set; } = null!;

        [Column("coupon_code")]
        public string CouponCode { get; set; } = null!;
    }
}
