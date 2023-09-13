namespace Ufinet.Dtos.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
