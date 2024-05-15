using System.Collections.Generic;
using System.Linq;
using CartService.Database.Entities;
using CartService.Database.Repositories.Interfaces;

namespace CartService.Database.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly List<CartEntity> _items = new List<CartEntity>();

        public CartEntity AddItem(CartEntity item)
        {
            _items.Add(item);
            return item;
        }

        public IEnumerable<CartEntity> GetItemsByUserId(int userId)
        {
            return _items.Where(i => i.UserId == userId);
        }

        public CartEntity UpdateItem(CartEntity item)
        {
            var existingItem = _items.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Quantity = item.Quantity;
            }
            return existingItem;
        }

        public bool DeleteItem(int itemId)
        {
            var item = _items.FirstOrDefault(i => i.Id == itemId);
            return item != null && _items.Remove(item);
        }
    }
}
