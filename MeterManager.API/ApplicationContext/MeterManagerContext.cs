using MeterManager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MeterManager.API.ApplicationContext
{
    public class MeterManagerContext : DbContext
    {
        public MeterManagerContext(DbContextOptions<MeterManagerContext> options)
            : base(options) { } 
        DbSet<MeterModel> Meters { get; set; }
    }
}
