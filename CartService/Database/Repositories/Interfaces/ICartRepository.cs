using CartService.Database.Entities;

namespace CartService.Database.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<bool> AddToCart(Guid userId, long offerId);
        Task InsertCartAsync(CartEntity cartEntity);
        Task<bool> RemoveFromCart(Guid userId, long offerId);
        Task SaveAsync();
    }
}
