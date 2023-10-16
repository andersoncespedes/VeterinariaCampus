using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class CitaRepository : GenericRepository<Citas>, ICita
{
    private APIContext _context;
    public CitaRepository(APIContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Mascota>> FindCitasTrimestreVacunacion()
    {
        return await _context.Set<Citas>()
            .Include(e => e.Mascota)
            .Where(e =>
                e.Fecha < new DateOnly(2023, 04, 01)
                && e.Fecha > new DateOnly(2023, 01, 01)
                && e.Motivo.ToLower() == "vacunacion")
            .Select(e => e.Mascota)
            .ToListAsync();
    }
    public async Task<IEnumerable<Mascota>> GetPerVeterinario(string nombreVet)
    {
        return await _context.Set<Citas>()
            .Include(e => e.Mascota)
            .Include(e => e.Veterinario)
            .Where(e => e.Veterinario.Nombre.ToLower() == nombreVet.ToLower())
            .Select(e => e.Mascota)
            .ToListAsync();
    }
}
