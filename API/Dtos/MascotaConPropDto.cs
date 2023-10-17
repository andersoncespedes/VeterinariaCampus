using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class MascotaConPropDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public DateOnly FechaNacimiento { get; set; }
    public string Raza { get; set; }
    public PropietarioDto Propietario {get; set;}
}
