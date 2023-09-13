using Ufinet.Dtos.Models;

namespace Ufinet.Dtos.Request
{
    public class RestaurantRequestDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int CountryId { get; set; }
    }
}
