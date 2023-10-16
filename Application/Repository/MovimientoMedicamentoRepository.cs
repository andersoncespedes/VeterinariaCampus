

using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;
public class MovimientoMedicamentoRepository : GenericRepository<MovimientoMedicamento>, IMovimientoMedicamento
{
    private APIContext _context;
    public MovimientoMedicamentoRepository(APIContext context) : base(context)
    {
        _context = context;
    }
    public async override void Add(MovimientoMedicamento entity)
    {
        foreach (var a in entity.DetalleMovimientos)
        {
            var dato = _context.Set<Medicamento>().Where(e => e.Id == a.IdProductoFk).FirstOrDefault();
            a.Precio = dato.Precio * a.Cantidad;
        }
        entity.Total = entity.DetalleMovimientos.Select(e => e.Precio).Sum();
        _context.Set<MovimientoMedicamento>().Add(entity);

    }
}
