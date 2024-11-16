using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MissionControlAPI.Models
{
    public class Mission
    {
        [Key]
        public int MissionId {  get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; }
        [Required]
        public string Objective { get; set; }
        [ForeignKey("Rocket")]
        public int RocketId { get; set; }
        public Rocket Rocket { get; set; }
    }
}
