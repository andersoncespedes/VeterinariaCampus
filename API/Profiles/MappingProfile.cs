using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Medicamento, MedicamentoDto>().ReverseMap();
        CreateMap<Laboratorio, LaboratorioDto>().ReverseMap();
        CreateMap<Mascota, MascotaDto>()
        .ForMember(e => e.Raza, opt => opt.MapFrom(e => e.Raza.Nombre))
        .ForMember(e => e.Especie, opt => opt.MapFrom(e => e.Especie.Nombre))
        .ReverseMap();

        CreateMap<Mascota, PostMascotaDto>().ReverseMap();
    }
}
