using GeekShopping.Cart.Data.ValueObjects.Models;

namespace GeekShopping.Cart.API.Data.ValueObjects
{
    public class CartVO
    {
        public CartHeaderVO CartHeader { get; set; }
        public IEnumerable<CartDetailVO> CartDetails { get; set; }
    }
}
