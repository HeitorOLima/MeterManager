using MeterManager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MeterManager.API.ApplicationContext
{
    public class MeterManagerDbContext : DbContext
    {
        public DbSet<MeterModel> Meters { get; set;}
        
        public MeterManagerDbContext(DbContextOptions<MeterManagerDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        } 
    }
}
