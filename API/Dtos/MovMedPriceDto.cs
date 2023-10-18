using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

public class MovMedPriceDto
{
    public int Id { get; set; }
    public DateOnly Fecha { get; set; }
    public string TipoMovimiento { get; set; }
    public double Total {get; set;}
}
