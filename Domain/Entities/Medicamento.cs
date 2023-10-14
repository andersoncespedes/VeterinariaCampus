using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Medicamento : BaseEntity
{
    public string Nombre { get; set; }
    public int CantidadDisponible {get; set;}
    public double Precio {get; set;}
    public int IdLaboratorioFk{get; set;}
    public Laboratorio Laboratorio { get; set; }
    public ICollection<MovimientoMedicamento> MovimientoMedicamentos {get;set;}
    public ICollection<TratamientoMedico> TratamientoMedicos {get; set;}
    public ICollection<MedicamentoProveedores> medicamentoProveedores {get; set;}
    public ICollection<Proveedor> Proveedores {get; set;}
}
