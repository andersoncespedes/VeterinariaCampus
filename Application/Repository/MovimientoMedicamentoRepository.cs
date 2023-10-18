

using Domain.Entities;
using Domain.Interface;
using Persistence.Data;
using Microsoft.EntityFrameworkCore;
namespace Application.Repository;
public class MovimientoMedicamentoRepository : GenericRepository<MovimientoMedicamento>, IMovimientoMedicamento
{
    private APIContext _context;
    public MovimientoMedicamentoRepository(APIContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<(int totalRegistros, IEnumerable<MovimientoMedicamento> registros)> paginacion(int pageIndex, int pageSize, string _search)
    {
        var totalRegistros = await _context.Set<MovimientoMedicamento>().CountAsync();
        var registros = await _context.Set<MovimientoMedicamento>()
            .Include(e => e.DetalleMovimientos)
            .Include(e => e.TipoMovimiento)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }
    public override void Add(MovimientoMedicamento entity)
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
