using System.Collections.Generic;
using CartService.Database.Entities;

namespace CartService.Database.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task SaveAsync();
    }
}
