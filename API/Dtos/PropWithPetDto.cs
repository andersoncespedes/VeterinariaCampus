

namespace API.Dtos;
public class PropWithPetDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public int Telefono { get; set; }
    public ICollection<MascotaDto> Mascotas { get; set; }
}
