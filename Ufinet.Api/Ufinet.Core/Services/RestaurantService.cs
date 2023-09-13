using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ufinet.Contracts.Interfaces.Repositories;
using Ufinet.Contracts.Interfaces.Services;
using Ufinet.Dtos.Models;
using Ufinet.Dtos.Request;
using Ufinet.Dtos.Responses;
using Ufinet.Infrastructure.Repositories;

namespace Ufinet.Core.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RestaurantResponseDto>> GetRestaurants()
        {
            var restaurants = await _restaurantRepository.FindBy(x => x.Active).AsNoTracking().ToListAsync();
            return _mapper.Map<IEnumerable<RestaurantResponseDto>>(restaurants);
        }

        public async Task<RestaurantResponseDto> GetRestaurantById(int restaurantId)
        {
            var restaurant = await _restaurantRepository.FindBy(x => x.Active && x.Id == restaurantId).AsNoTracking().FirstOrDefaultAsync();
            return _mapper.Map<RestaurantResponseDto>(restaurant);
        }

        public async Task<RestaurantResponseDto> AddRestaurant(RestaurantRequestDto restaurantRequest)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantRequest);
            restaurant.Active = true;
            await _restaurantRepository.Add(restaurant);
            return _mapper.Map<RestaurantResponseDto>(restaurant);
        }

        public async Task<RestaurantResponseDto> UpdateRestaurant(int restaurantId, RestaurantRequestDto restaurantRequest)
        {
            var restaurantDb = await _restaurantRepository.FindBy(x => x.Active && x.Id == restaurantId).FirstOrDefaultAsync();
            _mapper.Map(restaurantRequest, restaurantDb);

            await _restaurantRepository.Update(restaurantDb!);
            return _mapper.Map<RestaurantResponseDto>(restaurantDb);
        }

        public async Task<string> DeleteRestaurant(int restaurantId)
        {
            var restaurantDb = await _restaurantRepository.FindBy(x => x.Active && x.Id == restaurantId).FirstOrDefaultAsync();
            if (restaurantDb != null)
            {
                if (restaurantDb!.Active == true)
                {
                    restaurantDb.Active = false;
                }
                await _restaurantRepository.Update(restaurantDb!);
                return "El restaurante fue eliminado satisfactoriamente";
            }
            else
            {
                return "No hay ningun registro con este Id";
            }
        }
 
    }
}
