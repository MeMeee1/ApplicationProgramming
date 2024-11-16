namespace MissionControlAPI.Models.DTO
{
    public class PlanetDTO
    {
        public int PlanetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double DistanceFromSun { get; set; }
        public List<RocketDTO> Rockets { get; set; }
    }

}
