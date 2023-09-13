using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ufinet.Contracts.Interfaces.Repositories;
using Ufinet.Contracts.Interfaces.Services;
using Ufinet.Dtos.Filters;
using Ufinet.Dtos.Models;
using Ufinet.Dtos.Pagination;
using Ufinet.Dtos.Request;
using Ufinet.Dtos.Responses;

namespace Ufinet.Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IHotelRepository _hotelRepository;

        public CountryService(ICountryRepository countryRepository, IMapper mapper, IRestaurantRepository restaurantRepository, IHotelRepository hotelRepository)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
            _hotelRepository = hotelRepository;
        }

        public async Task<PaginatedCountriesResposeDto> GetCountries(QueryParamsDto paginated, CountryFilter filter)
        {
            var countries = _countryRepository.FindBy(x => x.Active);
            if (filter.Name != null)
            {
                countries = countries.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()));
            }
            if (filter.IsoCode != null)
            {
                countries = countries.Where(x => x.IsoCode.ToLower().Contains(filter.IsoCode.ToLower()));
            }
            if (filter.RestaurantName != null)
            {
                var restaurant = await _restaurantRepository.FindBy(x => x.Active && x.Name.ToLower().Contains(filter.RestaurantName.ToLower())).FirstOrDefaultAsync();
                countries = countries.Where(x => x.Restaurants.Contains(restaurant!));
            }
            if (filter.HotelName != null)
            {
                var hotel = await _hotelRepository.FindBy(x => x.Active && x.Name.ToLower().Contains(filter.HotelName.ToLower())).FirstOrDefaultAsync();
                countries = countries.Where(x => x.Hotels.Contains(hotel!));
            }

            var result = await countries.Include(x => x.Restaurants).Include(x => x.Hotels)
                .AsNoTracking().PaginateAsync(paginated);

            var countryResult = _mapper.Map<List<CountryResponseDto>>(result.Resource);

            var response = new PaginatedCountriesResposeDto
            {
                Countries = PaginationHelper.CreatePagedReponse<CountryResponseDto>(countryResult, paginated, result.TotalRecords)
            };

            return response;
        }

        public async Task<CountryResponseDto> GetCountryById(int countryId)
        {
            var country = await _countryRepository.FindBy(x => x .Active && x.Id == countryId).Include(x => x.Restaurants).Include(x => x.Hotels).AsNoTracking().FirstOrDefaultAsync();
            return _mapper.Map<CountryResponseDto>(country);
        }

        public async Task<CountryResponseDto> AddCountry(CountryRequestDto countryRequest)
        {
            var country = _mapper.Map<Country>(countryRequest);
            country.Active = true;
            await _countryRepository.Add(country);
            return _mapper.Map<CountryResponseDto>(country);
        }

        public async Task<CountryResponseDto> UpdateCountry(int countryId, CountryRequestDto countryRequest)
        {
            var countryDb = await _countryRepository.FindBy(x => x.Active && x.Id == countryId).FirstOrDefaultAsync();
            _mapper.Map(countryRequest, countryDb);

            await _countryRepository.Update(countryDb!);
            return _mapper.Map<CountryResponseDto>(countryDb);
        }

        public async Task<string> DeleteCountry(int countryId)
        {
            var countryDb = await _countryRepository.FindBy(x => x.Active && x.Id == countryId).FirstOrDefaultAsync();
            if(countryDb != null)
            {
                if (countryDb!.Active == true)
                {
                    countryDb.Active = false;
                }
                await _countryRepository.Update(countryDb!);
                return "La ciudad fue eliminada satisfactoriamente";
            }
            else
            {
                return "No hay ningun registro con este Id";
            }
            
        }
    }
}
