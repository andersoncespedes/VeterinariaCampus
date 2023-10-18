namespace Domain.Entities;
public class MedicamentoProveedores
{
    public int IdMedicamentoFk { get; set; }
    public Medicamento Medicamento { get; set; }
    public int IdProveedorFk { get; set; }
    public Proveedor Proveedor { get; set; }
}
