using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ufinet.Contracts.Interfaces.Repositories;
using Ufinet.Contracts.Interfaces.Services;
using Ufinet.Dtos.Models;
using Ufinet.Dtos.Request;
using Ufinet.Dtos.Responses;

namespace Ufinet.Core.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public HotelService(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HotelResponseDto>> GetHotels()
        {
            var hotels = await _hotelRepository.FindBy(x => x.Active).AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<HotelResponseDto>>(hotels);
        }

        public async Task<HotelResponseDto> GetHotelById(int hotelId)
        {
            var hotel = await _hotelRepository.FindBy(x => x.Active && x.Id == hotelId).AsNoTracking().FirstOrDefaultAsync();
            return _mapper.Map<HotelResponseDto>(hotel);
        }

        public async Task<HotelResponseDto> AddHotel(HotelRequestDto hotelRequest)
        {
            var hotel = _mapper.Map<Hotel>(hotelRequest);
            hotel.Active = true;
            await _hotelRepository.Add(hotel);
            return _mapper.Map<HotelResponseDto>(hotel);
        }

        public async Task<HotelResponseDto> UpdateHotel(int HotelId, HotelRequestDto hotelRequest)
        {
            var hotelDB = await _hotelRepository.FindBy(x => x.Active && x.Id == HotelId).FirstOrDefaultAsync();
            _mapper.Map(hotelRequest, hotelDB);

            await _hotelRepository.Update(hotelDB!);
            return _mapper.Map<HotelResponseDto>(hotelDB);
        }

        public async Task<string> DeleteHotel(int hotelId)
        {
            var hotelDB = await _hotelRepository.FindBy(x => x.Active && x.Id == hotelId).FirstOrDefaultAsync();
            if (hotelDB != null)
            {
                if (hotelDB!.Active == true)
                {
                    hotelDB.Active = false;
                }
                await _hotelRepository.Update(hotelDB!);
                return "El hotel fue eliminado satisfactoriamente";
            }
            else
            {
                return "No hay ningun registro con este Id";
            }
        }

    }
}
