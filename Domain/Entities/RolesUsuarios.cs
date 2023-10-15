

namespace Domain.Entities;

public class RolesUsuarios : BaseEntity
{
    public int IdUserFk { get; set; }
    public Usuario Usuario { get; set; }
    public int IdRolFk { get; set; }
    public Rol Rol { get; set; }
}
