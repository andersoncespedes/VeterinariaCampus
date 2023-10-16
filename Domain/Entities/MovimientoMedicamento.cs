namespace Domain.Entities;

public class MovimientoMedicamento : BaseEntity
{
    public DateOnly Fecha { get; set; }
    public int IdTipoMovFk { get; set; }
    public TipoMovimiento TipoMovimiento { get; set; }
    public ICollection<DetalleMovimiento> DetalleMovimientos { get; set; }
    public double Total { get; set; }
}
