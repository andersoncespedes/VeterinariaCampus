using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos;
public class PostMovimientoMedicamentoDto
{
    public DateOnly Fecha { get; set; }
    public int IdTipoMovFk { get; set; }
    public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; }
}
