using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Roles : BaseEntity
{
    public string Nombre { get; set; }
    public ICollection<Usuario> Usuarios { get; set; }
}
