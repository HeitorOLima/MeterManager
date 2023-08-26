using EnergyEndpointManager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EnergyEndpointManager.API.ApplicationContext
{
    public class EnergyEndpointManagerDbContext : DbContext
    {
        public DbSet<EnergyEndpoint> Meters { get; set;}
        
        public EnergyEndpointManagerDbContext(DbContextOptions<EnergyEndpointManagerDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        } 
    }
}
