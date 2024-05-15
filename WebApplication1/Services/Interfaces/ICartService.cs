using CartService.Database.Entities;
//using CartService.Models;

namespace CartService.Services.Interfaces;

public interface ICartService
{
    Task<CartEntity> AddItemToCart(CartEntity item);
    Task<IEnumerable<CartEntity>> GetCartItems(int userId);
    Task<CartEntity> UpdateCartItem(CartEntity item);
    Task<bool> RemoveItemFromCart(int itemId);
}