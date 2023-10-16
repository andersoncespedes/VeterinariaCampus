

namespace Domain.Entities;
public class Medicamento : BaseEntity
{
    public string Nombre { get; set; }
    public int CantidadDisponible { get; set; }
    public double Precio { get; set; }
    public int IdLaboratorioFk { get; set; }
    public Laboratorio Laboratorio { get; set; }
    public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; }
    public ICollection<TratamientoMedico> TratamientoMedicos { get; set; }
    public ICollection<MedicamentoProveedores> MedicamentoProveedores { get; set; }
    public ICollection<Proveedor> Proveedores { get; set; } = new HashSet<Proveedor>();
}
