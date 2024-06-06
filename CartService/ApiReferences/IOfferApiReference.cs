using CartService.Models.OfferServiceModels;
using Refit;

namespace CartService.ApiReferences;

public interface IOfferApiReference
{
    // referencja do pobierania ofert po ich id
    [Post("/offers")]
    Task<List<OffersResponse>> GetOffersByIds([Body] List<long> offerIds);
}