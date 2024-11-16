using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MissionControlAPI.Models
{
    public class Planet
    {
        [Key]
       
        public int PlanetId { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string Description = string.Empty;
        [Required]
        public double DistanceFromSun { get; set; }
        public ICollection<Rocket> Rockets { get; set; }

    }
}
