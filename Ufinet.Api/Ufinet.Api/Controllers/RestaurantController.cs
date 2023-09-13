using Microsoft.AspNetCore.Mvc;
using Ufinet.Contracts.Interfaces.Services;
using Ufinet.Core.Services;
using Ufinet.Dtos.Request;

namespace Ufinet.Api.Controllers
{
    [ApiController]
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> Consult()
        {
            var response = await _restaurantService.GetRestaurants();

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpGet("{restaurantId}")]
        public async Task<IActionResult> Get(int restaurantId)
        {
            var response = await _restaurantService.GetRestaurantById(restaurantId);

            if (response is null)
                return NotFound();

            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Add(RestaurantRequestDto restaurantRequest)
        {
            var response = await _restaurantService.AddRestaurant(restaurantRequest);

            if (response is null)
                return NotFound();

            return Ok(response);
        }


        [HttpPut("{restaurantId}")]
        public async Task<IActionResult> Updated(int restaurantId, RestaurantRequestDto restaurantRequest)
        {
            var response = await _restaurantService.UpdateRestaurant(restaurantId, restaurantRequest);

            if (response is null)
                return NotFound();

            return Ok(response);
        }


        [HttpDelete("{restaurantId}")]
        public async Task<IActionResult> Delete(int restaurantId)
        {
            var response = await _restaurantService.DeleteRestaurant(restaurantId);

            if (response is null)
                return NotFound();

            return Ok(response);
        }
    }
}
