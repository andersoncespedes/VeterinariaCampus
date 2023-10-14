namespace Domain.Entities;

public class MovimientoMedicamento : BaseEntity
{
    public int IdProductoFk {get; set;}
    public Medicamento Medicamento {get; set;}
    public int Cantidad {get; set;}
    public DateOnly Fecha {get; set;}
    public int IdTipoMovFk {get; set;}
    public TipoMovimiento TipoMovimiento {get; set;}
}
