

namespace API.Dtos;
public class CitaDto
{
    public int Id { get; set; }
    public MascotaDto Mascota { get; set; }
    public DateOnly Fecha { get; set; }
    public TimeOnly Hora { get; set; }
    public string Motivo { get; set; }
    public string Veterinario { get; set; }
    public ICollection<TratamientoMedicoDto> TratamientoMedicos { get; set; }
}
