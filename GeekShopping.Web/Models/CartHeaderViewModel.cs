namespace GeekShopping.Web.Models
{
    public class CartHeaderViewModel
    {
        public long Id { get; set; }
        public string UserId { get; set; } = null!;
        public string CouponCode { get; set; } = null!;
        public decimal PurchaseAmount { get; set; }
    }
}
