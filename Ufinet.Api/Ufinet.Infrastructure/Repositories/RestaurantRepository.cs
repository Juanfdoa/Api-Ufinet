using Ufinet.Contracts.Interfaces.Repositories;
using Ufinet.Dtos.Models;

namespace Ufinet.Infrastructure.Repositories
{
    public class RestaurantRepository : BaseRepository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(ApplicationDbContext context): base(context)
        {
            
        }
    }
}
