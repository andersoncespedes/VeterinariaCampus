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

        CreateMap<Proveedor, ProveedorDto>().ReverseMap();

        CreateMap<Propietario, PropietarioDto>().ReverseMap();

        CreateMap<Citas, CitaDto>().ReverseMap();

        CreateMap<Especie, EspecieDto>().ReverseMap();

        CreateMap<Veterinario, VeterinarioDto>().ReverseMap();

        CreateMap<Especie, EspecieWithPetDto>().ReverseMap();

        CreateMap<Propietario, PropWithPetDto>().ReverseMap();

        CreateMap<DetalleMovimiento, DetalleMovimientoDto>()
        .ForMember(e => e.Medicamento, opt => opt.MapFrom(e => e.Medicamento.Nombre))
        .ReverseMap();

        CreateMap<MovimientoMedicamento, MovimientoMedicamentoDto>()
        .ForMember(e => e.Medicamento, opt => opt.MapFrom(e => e.Medicamento.Nombre))
        .ForMember(e => e.TipoMovimiento, opt => opt.MapFrom(e => e.TipoMovimiento.Descripcion))
        .ReverseMap();
    }
}
