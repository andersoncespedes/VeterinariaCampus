using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
{
    private APIContext _context;
    public ProveedorRepository(APIContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Proveedor>> GetPerMedicamento(string nombre)
    {
        return await _context.Set<Proveedor>()
            .Include(e => e.Medicamentos)
            .Where(e => e.Medicamentos.Where(e => e.Nombre.ToLower() == nombre.ToLower()).Any())
            .ToListAsync();
    }
}
