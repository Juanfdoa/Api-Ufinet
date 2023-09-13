using Microsoft.AspNetCore.Mvc;
using Ufinet.Contracts.Interfaces.Services;
using Ufinet.Core.Services;
using Ufinet.Dtos.Request;

namespace Ufinet.Api.Controllers
{
    [ApiController]
    [Route("api/hotel")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> Consult()
        {
            var response = await _hotelService.GetHotels();

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpGet("{hotelId}")]
        public async Task<IActionResult> Get(int hotelId)
        {
            var response = await _hotelService.GetHotelById(hotelId);

            if (response is null)
                return NotFound();

            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Add(HotelRequestDto hotelRequest)
        {
            var response = await _hotelService.AddHotel(hotelRequest);

            if (response is null)
                return NotFound();

            return Ok(response);
        }


        [HttpPut("{hotelId}")]
        public async Task<IActionResult> Updated(int hotelId, HotelRequestDto hotelRequest)
        {
            var response = await _hotelService.UpdateHotel(hotelId, hotelRequest);

            if (response is null)
                return NotFound();

            return Ok(response);
        }


        [HttpDelete("{hotelId}")]
        public async Task<IActionResult> Delete(int hotelId)
        {
            var response = await _hotelService.DeleteHotel(hotelId);

            if (response is null)
                return NotFound();

            return Ok(response);
        }
    }
}
