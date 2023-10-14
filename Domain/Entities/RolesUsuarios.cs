using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class RolesUsuarios
{
    public int IdUserFk {get; set;}
    public Usuario Usuario {get; set;}
    public int IdRolFk {get; set;}
    public Roles Roles {get; set;}
}
