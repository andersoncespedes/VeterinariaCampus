

namespace Domain.Entities;

public class Rol : BaseEntity
{
    public string Nombre { get; set; }
    public ICollection<Usuario> Usuarios { get; set; } = new HashSet<Usuario>();
    public ICollection<RolesUsuarios> RolesUsuarios { get; set; }
}
