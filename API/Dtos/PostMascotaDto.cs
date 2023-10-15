using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos;

public class PostMascotaDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public DateOnly FechaNacimiento { get; set; }
    public int IdRazaFk { get; set; }
    public int IdEspecieFk { get; set; }
    public Propietario Propietario { get; set; }
}
