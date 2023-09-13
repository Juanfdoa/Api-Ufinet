using Ufinet.Contracts.Interfaces.Repositories;
using Ufinet.Dtos.Models;

namespace Ufinet.Infrastructure.Repositories
{
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
