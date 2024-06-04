using Microsoft.AspNetCore.Mvc;
using CartService.Database.Entities;
using CartService.Database.Repositories.Interfaces;
using CartService.Models;
using CartService.Models.OfferServiceModels;
using CartService.Services.Interfaces;
using Refit;

namespace CartService.Controllers;

[ApiController]
[Route("cart")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    // [HttpGet("{userId}")]
    // public async Task<ActionResult<List<Offer>>> GetOffersInCart(Guid userId)
    // {
    //    
    // }
    //
    // [HttpPost]
    // public async Task<ActionResult<CartEntity>> CreateCart(Guid userId)
    // {
    //     
    // }
    //
    // [HttpPatch]
    // public async Task<ActionResult<CartEntity>> UpdateCartItem(CartEntity cartEntity)
    // {
    //     
    // }
    //
    // [HttpDelete("{userId}")]
    // public async Task<ActionResult<bool>> RemoveItemFromCart(Guid userId, long offerId)
    // {
    //     
    // }
    [HttpPost]
    public async Task<ActionResult<List<OffersResponse>>> GetOffersByIds(List<long> offerIds)
    {
        try
        {
            return Ok(await _cartService.GetOffersByIds(offerIds));
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}