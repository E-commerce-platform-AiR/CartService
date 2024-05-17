using Microsoft.AspNetCore.Mvc;
using CartService.Database.Entities;
using CartService.Database.Repositories.Interfaces;
using CartService.Services.Interfaces;

namespace CartService.Controllers
{
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ICartRepository _cartRepository;

        public CartController(ICartService cartService, ICartRepository cartRepository)
        {
            _cartService = cartService;
            _cartRepository = cartRepository;
        }

        [HttpGet("carts/{userId}")]
        public async Task<ActionResult<List<CartEntity>>> GetCartItems(int userId)
        {
            var cartItems = _cartRepository.GetItemsByUserId(userId);
            return Ok(cartItems);
        }

        [HttpPost("carts")]
        public async Task<ActionResult<CartEntity>> AddItemToCart([FromBody] CartEntity cartItem)
        {
            try
            {
                return Ok(await _cartService.AddItemToCart(cartItem));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("carts")]
        public async Task<ActionResult<CartEntity>> UpdateCartItem([FromBody] CartEntity cartItem)
        {
            try
            {
                return Ok(await _cartService.UpdateCartItem(cartItem));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("carts/{itemId}")]
        public async Task<ActionResult> RemoveItemFromCart(int itemId)
        {
            try
            {
                var result = await _cartService.RemoveItemFromCart(itemId);
                if (result)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
