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
        return await _context.Set<Medicamento>()
            .Where(e => e.Nombre.ToLower() == nombre.ToLower())
            .Include(e => e.Proveedores)
            .SelectMany(e => e.Proveedores)
            .ToListAsync();
    }
}
