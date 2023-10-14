
namespace Domain.Entities;
public class Veterinario : BaseEntity
{
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public int Telefono { get; set; }
    public string Especialidad { get; set; }
    public ICollection<Citas> Citas { get; set; }
}
