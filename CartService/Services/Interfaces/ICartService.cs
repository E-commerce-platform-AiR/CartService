using CartService.Database.Entities;
using CartService.Models.OfferServiceModels;

namespace CartService.Services.Interfaces;

public interface ICartService
{
    Task<bool> AddToCart(Guid userId, long offerId);
    Task<CartEntity> CreateCart(Guid userId);
    Task<List<OffersResponse>> GetOffersByIds(List<long> offerIds);
    Task<bool> RemoveFromCart(Guid userId, long offerId);

}