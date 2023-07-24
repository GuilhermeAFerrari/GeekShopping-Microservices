using GeekShopping.Cart.API.Data.ValueObjects;
using GeekShopping.Cart.API.Messages;
using GeekShopping.Cart.API.RabbitMQSender;
using GeekShopping.Cart.API.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Cart.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _repository;
        private readonly IRabbitMQMessageSender _messageSender;

        public CartController(ICartRepository repository, IRabbitMQMessageSender messageSender)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
        }

        [HttpGet("find-cart/{id}")]
        public async Task<ActionResult<IEnumerable<CartVO>>> FindById(string id)
        {
            var cart = await _repository.FindCartByUserId(id);
            if (cart is null) return NotFound();
            return Ok(cart);
        }

        [HttpPost("add-cart")]
        public async Task<ActionResult<CartVO>> AddCart(CartVO vo)
        {
            var cart = await _repository.SaveOrUpdateCart(vo);
            if (cart is null) return NotFound();
            return Ok(cart);
        }

        [HttpPut("update-cart")]
        public async Task<ActionResult<CartVO>> UpdateCart(CartVO vo)
        {
            var cart = await _repository.SaveOrUpdateCart(vo);
            if (cart is null) return NotFound();
            return Ok(cart);
        }

        [HttpDelete("remove-cart/{id}")]
        public async Task<ActionResult<CartVO>> RemoveCart(int id)
        {
            var status = await _repository.RemoveFromCart(id);
            if (!status) return BadRequest();
            return Ok(status);
        }

        [HttpPost ("apply-coupon")]
        public async Task<ActionResult<CartVO>> ApplyCoupon(CartVO model)
        {
            var status = await _repository.ApplyCoupon(model.CartHeader.UserId, model.CartHeader.CouponCode);
            if (!status) return BadRequest();
            return Ok(status);
        }

        [HttpDelete("remove-coupon/{userId}")]
        public async Task<ActionResult<CartVO>> RemoveCoupon(string userId)
        {
            var status = await _repository.RemoveCoupon(userId);
            if (!status) return BadRequest();
            return Ok(status);
        }

        [HttpPost("checkout")]
        public async Task<ActionResult<CheckoutHeaderVO>> Checkout(CheckoutHeaderVO vo)
        {
            if (vo?.UserId is null) return BadRequest();

            var cart = await _repository.FindCartByUserId(vo.UserId);
            if (cart is null) return NotFound();

            vo.CartDetails = cart.CartDetails;
            vo.DateTime = DateTime.Now;

            _messageSender.SendMessage(vo, "checkoutqueue");

            return Ok(vo);
        }
    }
}