using AutoMapper;
using ProjectInit.Core.Entities;
using ProjectInit.Infrastructure.DTOs;

namespace ProjectInit.API.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pet,PetDto>().ReverseMap();
            CreateMap<Pet,PetCreateDto>().ReverseMap();
            CreateMap<Pet,PetUpdateDto>().ReverseMap();
        }
    }
}
