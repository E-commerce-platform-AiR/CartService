using CartService.ApiReferences;
using CartService.Database.Entities;
using CartService.Database.Repositories.Interfaces;
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


    public async Task<bool> AddToCart(Guid userId, long offerId)
    {
        await _cartRepository.AddToCart(userId, offerId);
        await _cartRepository.SaveAsync();
        return true;
    }
   
    public async Task<CartEntity> CreateCart(Guid userId)
    {
        CartEntity cartEntity = new CartEntity(userId);
        await _cartRepository.InsertCartAsync(cartEntity);
        await _cartRepository.SaveAsync();
        return cartEntity;
    }
    
    public async Task<bool> RemoveFromCart(Guid userId, long offerId)
    {
        await _cartRepository.RemoveFromCart(userId, offerId);
        await _cartRepository.SaveAsync();
        return true;
    }

    public async Task<List<OffersResponse>> GetOffersByIds(List<long> offerIds)
    {
        var response = await _offerApiReference.GetOffersByIds(offerIds);
        return response;

    }
}