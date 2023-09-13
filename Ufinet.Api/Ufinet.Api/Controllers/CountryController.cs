using Microsoft.AspNetCore.Mvc;
using Ufinet.Contracts.Interfaces.Services;
using Ufinet.Dtos.Filters;
using Ufinet.Dtos.Pagination;
using Ufinet.Dtos.Request;

namespace Ufinet.Api.Controllers
{
    [ApiController]
    [Route("api/country")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> Consult([FromQuery] QueryParamsDto pagination, [FromQuery] CountryFilter filter)
        {
            var response = await _countryService.GetCountries(pagination, filter);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpGet("{countryId}")]
        public async Task<IActionResult> Get(int countryId)
        {
            var response = await _countryService.GetCountryById(countryId);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

       
        [HttpPost]
        public async Task<IActionResult> Add(CountryRequestDto countryRequest)
        {
            var response = await _countryService.AddCountry(countryRequest);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

       
        [HttpPut("{countryId}")]
        public async Task<IActionResult> Updated(int countryId, CountryRequestDto countryRequest)
        {
            var response = await _countryService.UpdateCountry(countryId, countryRequest);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        
        [HttpDelete("{countryId}")]
        public async Task<IActionResult> Delete(int countryId)
        {
            var response = await _countryService.DeleteCountry(countryId);

            if (response is null)
                return NotFound();

            return Ok(response);
        }
    }
}
