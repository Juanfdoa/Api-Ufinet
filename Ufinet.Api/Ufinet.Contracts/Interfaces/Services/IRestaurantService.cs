using Ufinet.Dtos.Request;
using Ufinet.Dtos.Responses;

namespace Ufinet.Contracts.Interfaces.Services
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantResponseDto>> GetRestaurants();
        Task<RestaurantResponseDto> GetRestaurantById(int restaurantId);
        Task<RestaurantResponseDto> AddRestaurant(RestaurantRequestDto restaurantRequest);
        Task<RestaurantResponseDto> UpdateRestaurant(int restaurantId, RestaurantRequestDto restaurantRequest);
        Task<string> DeleteRestaurant(int restaurantId);
    }
}
