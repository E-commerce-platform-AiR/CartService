using CartService.Database.DbContext;
using CartService.Database.Repositories.Interfaces;

namespace CartService.Database.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly CartDbContext _dbContext;
        public CartRepository(CartDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
