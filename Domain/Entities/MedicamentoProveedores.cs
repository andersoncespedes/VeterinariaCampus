namespace Domain.Entities;
public class MedicamentoProveedores : BaseEntity
{
    public int IdMedicamentoFk { get; set; }
    public Medicamento Medicamento { get; set; }
    public int IdProveedorFk { get; set; }
    public Proveedor Proveedor { get; set; }
}
