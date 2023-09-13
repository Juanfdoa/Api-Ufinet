using Ufinet.Dtos.Models;
using Ufinet.Dtos.Pagination;

namespace Ufinet.Dtos.Responses
{
    public class PaginatedCountriesResposeDto
    {
        public PagedResponseDto<IEnumerable<CountryResponseDto>>? Countries { get; set; }
    }
}
