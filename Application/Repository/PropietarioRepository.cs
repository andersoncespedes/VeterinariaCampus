
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class PropietarioRepository : GenericRepository<Propietario>, IPropietario
{
    private APIContext _context;
    public PropietarioRepository(APIContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Propietario>> ObtenerConMascota()
    {
        return await _context.Set<Propietario>()
            .Include(e => e.Mascotas)
            .ToListAsync();
    }
}
