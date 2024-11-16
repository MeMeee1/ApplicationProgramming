namespace MissionControlAPI.Models.DTO
{
    public class RocketDTO
    {
        public int RocketId { get; set; }
        public string RocketName { get; set; }
        public string Type { get; set; }
        public DateTime LaunchDate { get; set; }
        public int PlanetId { get; set; }
        public string PlanetName { get; set; }
        public List<MissionDTO> Missions { get; set; }
    }

}
