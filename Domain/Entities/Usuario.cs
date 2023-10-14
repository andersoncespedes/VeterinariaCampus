using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Usuario : BaseEntity
{
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string Contraseña { get; set; }
    public ICollection<Roles> Roles { get; set; }
}
