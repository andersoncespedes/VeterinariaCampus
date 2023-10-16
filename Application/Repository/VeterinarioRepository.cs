using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;
public class VeterinarioRepository : GenericRepository<Veterinario>, IVeterinario
{
    private APIContext _context;
    public VeterinarioRepository(APIContext context) : base(context)
    {
        _context = context;
    }
}
