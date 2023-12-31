using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos;
public class MovimientoMedicamentoDto
{
    public int Id { get; set; }
    public DateOnly Fecha { get; set; }
    public string TipoMovimiento { get; set; }
    public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; }
}
