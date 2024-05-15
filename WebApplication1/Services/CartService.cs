using System.Collections.Generic;
using System.Threading.Tasks;
using CartService.Database.Entities;
using CartService.Database.Repositories.Interfaces;
using CartService.Services.Interfaces;

namespace CartService.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartEntity> AddItemToCart(CartEntity item)
        {
            return _cartRepository.AddItem(item);
        }

        public async Task<IEnumerable<CartEntity>> GetCartItems(int userId)
        {
            return _cartRepository.GetItemsByUserId(userId);
        }

        public async Task<CartEntity> UpdateCartItem(CartEntity item)
        {
            return _cartRepository.UpdateItem(item);
        }

        public async Task<bool> RemoveItemFromCart(int itemId)
        {
            return _cartRepository.DeleteItem(itemId);
        }
    }
}
