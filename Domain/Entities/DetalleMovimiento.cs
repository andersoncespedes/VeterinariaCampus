namespace Domain.Entities;
public class DetalleMovimiento : BaseEntity
{
    public int IdProductoFk {get; set;}
    public Medicamento Medicamento {get; set;}
    public int Cantidad {get; set;}
    public int IdMovMedFk {get;set;}
    public MovimientoMedicamento MovimientoMedicamento {get; set;}
    public double Precio {get; set;}
}
