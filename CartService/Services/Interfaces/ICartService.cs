using CartService.Models.OfferServiceModels;

namespace CartService.Services.Interfaces;

public interface ICartService
{
    Task<List<OffersResponse>> GetOffersByIds(List<long> offerIds);
}