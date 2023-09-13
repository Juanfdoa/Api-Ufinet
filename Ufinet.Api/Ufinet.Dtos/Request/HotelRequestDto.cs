using Ufinet.Dtos.Models;

namespace Ufinet.Dtos.Request
{
    public class HotelRequestDto
    {
        public string Name { get; set; }
        public int Starts { get; set; }
        public int CountryId { get; set; }
    }
}
