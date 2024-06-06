using CartService.Database.DbContext;
using CartService.Database.Entities;
using CartService.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CartService.Database.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly CartDbContext _dbContext;
        public CartRepository(CartDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddToCart(Guid userId, long offerId)
        {
            var cart = await _dbContext.Carts.FirstOrDefaultAsync(x => x.UserId == userId);
            if (cart == null) return false;
            cart.Offers?.Add(offerId);
            return true;
        }
        public async Task InsertCartAsync(CartEntity cartEntity)
        {
            await _dbContext.Carts.AddAsync(cartEntity);
        }

        public async Task<bool> RemoveFromCart(Guid userId, long offerId)
        {
            var cart = await _dbContext.Carts.FirstOrDefaultAsync(x => x.UserId == userId);
            if (cart == null) return false;
            cart.Offers?.Remove(offerId);
            return true;
        }
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

