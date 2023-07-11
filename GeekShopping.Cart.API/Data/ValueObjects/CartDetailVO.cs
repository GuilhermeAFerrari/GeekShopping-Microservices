using GeekShopping.Cart.API.Data.ValueObjects;

namespace GeekShopping.Cart.Data.ValueObjects.Models
{
    public class CartDetailVO
    {
        public long? Id { get; set; }
        public long? CartHeaderId { get; set; }
        public CartHeaderVO? CartHeader { get; set; }
        public long? ProductId { get; set; }
        public ProductVO Product { get; set; }
        public int Count { get; set; }
    }
}
