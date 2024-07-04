using AutoMapper;
using PilotoWebAPI.Dtos;
using PilotoWebAPI.Models;


namespace PilotoWebAPI.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Piloto, PilotoDto>()
            .ForMember(dest => dest.Cant_hrs_vuelo, opt => opt.MapFrom(src => src.CantHrVuelo))
            .ForMember(dest => dest.idPais, opt => opt.MapFrom(src => src.Pais))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<PilotoDto, Piloto>()
            .ForMember(dest => dest.CantHrVuelo, opt => opt.MapFrom(src => src.Cant_hrs_vuelo))
            .ForMember(dest => dest.Pais, opt => opt.MapFrom(src => src.idPais))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<Piloto, PilotosDto>()
           .ForMember(dest => dest.Cant_hrs_vuelo, opt => opt.MapFrom(src => src.CantHrVuelo))
           .ForMember(dest => dest.pais_id, opt => opt.MapFrom(src => src.Pais))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.Id_Piloto, opt => opt.MapFrom(src => src.IdPiloto));
         
            CreateMap<Paise, PaisDto>();

            CreateMap<Piloto, PilotoDtoUpdate>();
            CreateMap<PilotoDtoUpdate, Piloto>();
        }
    }
}
