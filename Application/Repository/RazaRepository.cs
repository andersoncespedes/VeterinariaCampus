using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;
public class RazaRepository : GenericRepository<Raza>, IRaza
{
    private APIContext _context;
    public RazaRepository(APIContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<(int totalRegistros, IEnumerable<Raza> registros)> paginacion(int pageIndex, int pageSize, string _search)
    {
        var totalRegistros = await _context.Set<Raza>().CountAsync();
        var registros = await _context.Set<Raza>()
            .Include(e => e.Mascotas )
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }
}
