
using AutoMapper;
using MissionControlAPI.Models;
using System;
namespace MissionControlAPI.Models.DTO
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping from Planet to PlanetDTO
            CreateMap<Planet, PlanetDTO>()
                .ForMember(dest => dest.Rockets, opt => opt.MapFrom(src => src.Rockets));

            // Mapping from Rocket to RocketDTO
            CreateMap<Rocket, RocketDTO>()
                .ForMember(dest => dest.Missions, opt => opt.MapFrom(src => src.Missions))
                .ForMember(dest => dest.PlanetName, opt => opt.MapFrom(src => src.Planet.Name));

            // Mapping from Mission to MissionDTO
            CreateMap<Mission, MissionDTO>();

            // If you need reverse mapping, you can add these:
            CreateMap<PlanetDTO, Planet>()
                .ForMember(dest => dest.Rockets, opt => opt.MapFrom(src => src.Rockets));

            CreateMap<RocketDTO, Rocket>()
                .ForMember(dest => dest.Missions, opt => opt.MapFrom(src => src.Missions));

            CreateMap<MissionDTO, Mission>();
        }
    }
}
