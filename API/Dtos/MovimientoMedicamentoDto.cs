using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class MovimientoMedicamentoDto
{
    public int Id { get; set; }
    public string Medicamento { get; set; }
    public int Cantidad { get; set; }
    public DateOnly Fecha { get; set; }
    public string TipoMovimiento { get; set; }
}
