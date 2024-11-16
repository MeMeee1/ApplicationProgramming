using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MissionControlAPI.Models
{
    public class Rocket
    {
        [Key]
        public int RocketId { get; set; }
        [Required, MaxLength]
        public string RocketName { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime LaunchDate { get; set; } = DateTime.Now;
        [ForeignKey("Planet")]
        public int PlanetId { get; set; }
        public Planet Planet { get; set; }
        public ICollection<Mission>Missions { get; set; }

    }
}
