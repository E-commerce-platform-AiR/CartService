using System.Collections;
using CartService.ApiReferences;
using CartService.ApiReferences.RequestBodies;
using CartService.Database.Entities;
using CartService.Database.Repositories.Interfaces;
using CartService.Models;
using CartService.Models.OfferServiceModels;
using CartService.Services.Interfaces;

namespace CartService.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IOfferApiReference _offerApiReference;

    public CartService(ICartRepository cartRepository, IOfferApiReference offerApiReference)
    {
        _cartRepository = cartRepository;
        _offerApiReference = offerApiReference;
    }


    // public async Task<IEnumerable<Offer>> GetOffersInCart(Guid userId)
    // {
    //     
    // }
    //
    // public async Task<CartEntity> CreateCart(Guid userId)
    // {
    //     
    // }
    //
    // public async Task<CartEntity> UpdateCartItem(CartEntity cartEntity)
    // {
    //     
    // }
    //
    // public async Task<bool> RemoveItemFromCart(Guid userId, long offerId)
    // {
    //     
    // }

    public async Task<List<OffersResponse>> GetOffersByIds(List<long> offerIds)
    {
        var response = await _offerApiReference.GetOffersByIds(offerIds);
        return response;

    }
}