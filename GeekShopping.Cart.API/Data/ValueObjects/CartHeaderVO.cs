namespace GeekShopping.Cart.API.Data.ValueObjects
{
    public class CartHeaderVO
    {
        public long Id { get; set; }
        public string UserId { get; set; } = null!;
        public string CouponCode { get; set; } = null!;
    }
}
