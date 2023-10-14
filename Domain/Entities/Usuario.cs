

namespace Domain.Entities;

public class Usuario : BaseEntity
{
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string Contraseña { get; set; }
    public ICollection<Rol> Roles { get; set; }
    public ICollection<RolesUsuarios> RolesUsuarios { get; set; }
}
