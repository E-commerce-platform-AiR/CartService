using System.Collections.Generic;
using CartService.Database.Entities;

namespace CartService.Database.Repositories.Interfaces
{
    public interface ICartRepository
    {
        CartEntity AddItem(CartEntity item);
        IEnumerable<CartEntity> GetItemsByUserId(int userId);
        CartEntity UpdateItem(CartEntity item);
        bool DeleteItem(int itemId);
    }
}
