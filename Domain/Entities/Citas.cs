using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Citas : BaseEntity
{
    public int IdMascotaFk {get; set;}
    public Mascota Mascota {get; set;}
    public DateOnly Fecha {get; set;}
    public TimeOnly Hora {get; set;}
    public string Motivo {get; set;}
    public int IdVeterinario {get; set;}
    public Veterinario Veterinario {get; set;}
}
