namespace Ufinet.Dtos.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Starts { get; set; }
        public bool Active { get; set; }
        public int CountryId { get; set; }

        public Country Country { get; set; }
    }
}
