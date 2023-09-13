namespace Ufinet.Dtos.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public string Population { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
