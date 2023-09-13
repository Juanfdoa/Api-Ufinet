using Ufinet.Dtos.Models;

namespace Ufinet.Dtos.Responses
{
    public class CountryResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public string Population { get; set; }
        public virtual ICollection<RestaurantResponseDto> Restaurants { get; set; }

        public virtual ICollection<HotelResponseDto> Hotels { get; set; }
    }
}
