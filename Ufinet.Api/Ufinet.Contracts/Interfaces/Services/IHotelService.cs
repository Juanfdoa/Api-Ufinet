using Ufinet.Dtos.Request;
using Ufinet.Dtos.Responses;

namespace Ufinet.Contracts.Interfaces.Services
{
    public interface IHotelService
    {
        Task<IEnumerable<HotelResponseDto>> GetHotels();
        Task<HotelResponseDto> GetHotelById(int hotelId);
        Task<HotelResponseDto> AddHotel(HotelRequestDto hotelRequest);
        Task<HotelResponseDto> UpdateHotel(int HotelId, HotelRequestDto hotelRequest);
        Task<string> DeleteHotel(int hotelId);
    }
}
