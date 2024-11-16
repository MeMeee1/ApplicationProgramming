namespace MissionControlAPI.Models.DTO
{
    public class MissionDTO
    {
        public int MissionId { get; set; }
        public string Title { get; set; }
        public string Objective { get; set; }
        public int RocketId { get; set; }
        public string RocketName { get; set; }
    }

}
