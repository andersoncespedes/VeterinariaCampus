using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class DetalleMovimientoDto
{
    public string Medicamento { get; set; }
    public int Cantidad { get; set; }
    public int IdMovMedFk { get; set; }
    public int Precio { get; set; }
}
