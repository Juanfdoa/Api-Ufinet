using Ufinet.Dtos.Filters;
using Ufinet.Dtos.Pagination;
using Ufinet.Dtos.Request;
using Ufinet.Dtos.Responses;

namespace Ufinet.Contracts.Interfaces.Services
{
    public interface ICountryService
    {
        Task<PaginatedCountriesResposeDto> GetCountries(QueryParamsDto paginated, CountryFilter filter);
        Task<CountryResponseDto> GetCountryById(int countryId);
        Task<CountryResponseDto> AddCountry(CountryRequestDto countryRequest);
        Task<CountryResponseDto> UpdateCountry(int countryId, CountryRequestDto countryRequest);
        Task<string> DeleteCountry(int countryId);
    }
}
