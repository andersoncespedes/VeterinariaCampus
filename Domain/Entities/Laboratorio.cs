using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Laboratorio : BaseEntity
{
    public string Nombre { get; set; }
    public string Direccion {get; set; }
    public string Telefono  { get; set; }
}
