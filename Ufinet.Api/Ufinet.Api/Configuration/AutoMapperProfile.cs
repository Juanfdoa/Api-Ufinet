using AutoMapper;
using Ufinet.Dtos.Models;
using Ufinet.Dtos.Request;
using Ufinet.Dtos.Responses;

namespace Ufinet.Api.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Country, CountryResponseDto>().ReverseMap();
            CreateMap<CountryRequestDto, CountryResponseDto>().ReverseMap();
            CreateMap<Country, CountryRequestDto>().ReverseMap();

            CreateMap<Restaurant, RestaurantResponseDto>().ReverseMap();
            CreateMap<RestaurantRequestDto, RestaurantResponseDto>().ReverseMap();
            CreateMap<Restaurant, RestaurantRequestDto>().ReverseMap();

            CreateMap<Hotel, HotelResponseDto>().ReverseMap();
            CreateMap<HotelRequestDto, HotelResponseDto>().ReverseMap();
            CreateMap<Hotel, HotelRequestDto>().ReverseMap();
        }
    }
}
