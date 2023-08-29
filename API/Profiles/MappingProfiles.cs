using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Country, CountryDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.NameCountry))
            .ReverseMap();
            CreateMap<State, StateDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.StateName, opt => opt.MapFrom(src => src.NameState))
            .ForMember(dest => dest.IdCountry, opt => opt.MapFrom(src => src.IdCountryFK))
            .ReverseMap();
        }
    }
}