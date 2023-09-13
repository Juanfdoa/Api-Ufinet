using Ufinet.Contracts.Interfaces.Repositories;
using Ufinet.Dtos.Models;

namespace Ufinet.Infrastructure.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext context) : base(context) { }
    }
}
