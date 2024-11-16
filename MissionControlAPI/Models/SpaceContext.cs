using Microsoft.EntityFrameworkCore;
namespace MissionControlAPI.Models
{
    public class SpaceContext:DbContext
    {
        public SpaceContext(DbContextOptions<SpaceContext> options) : base(options) { }

        public DbSet<Planet> Planets{ get; set; }
        public DbSet<Rocket> Rockets{ get; set; }
        public DbSet<Mission> Missions{ get; set; }
    }
}
