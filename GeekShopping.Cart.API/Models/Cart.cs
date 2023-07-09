using System.Reflection.PortableExecutable;

namespace GeekShopping.Cart.API.Models
{
    public class Cart
    {
        public CartHeaderEntity? CartHeader { get; set; }
        public IEnumerable<CartDetailEntity>? CartDetails { get; set; }
    }
}
