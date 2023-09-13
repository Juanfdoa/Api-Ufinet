using Microsoft.EntityFrameworkCore;
using Ufinet.Dtos.Models;

namespace Ufinet.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<Country> Country { get; set; }
        public DbSet<Restaurant> Restaurant { get; set;}
        public DbSet<Hotel> Hotel { get; set; }
    }
}
