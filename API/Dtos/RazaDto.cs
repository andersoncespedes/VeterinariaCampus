using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class RazaDto
{
    public int Id {get; set;}
    public string Nombre { get; set; }
    public int IdEspecieFk { get; set; }
    public EspecieDto Especie { get; set; }
}