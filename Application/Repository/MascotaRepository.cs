using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;
using System.Linq.Expressions;

namespace Application.Repository;
public class MascotaRepository : GenericRepository<Mascota>, IMascota
{
    private readonly APIContext _context;
    public MascotaRepository(APIContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<(int totalRegistros, IEnumerable<Mascota> registros)> paginacion(int pageIndex, int pageSize, string _search)
    {
        var totalRegistros = await _context.Set<Mascota>().CountAsync();
        var registros = await _context.Set<Mascota>()
            .Include(e => e.Especie)
            .Include(e => e.Raza)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }
    public override IEnumerable<Mascota> Find(Expression<Func<Mascota, bool>> expression)
    {
        return _context.Set<Mascota>()
        .Include(e => e.Especie)
        .Include(e => e.Raza)
        .Where(expression);
    }
    public async Task<IEnumerable<Mascota>> GetGolden(){
        return await _context.Set<Mascota>()
        .Include(e => e.Raza)
        .Include(e => e.Propietario)
        .Where(e => e.Raza.Nombre.ToLower() == "golden retriever")
        .ToListAsync();
    }
}
