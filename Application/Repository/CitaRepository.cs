using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;
public class CitaRepository : GenericRepository<Citas>, ICita
{
    public CitaRepository(APIContext context) : base(context)
    {
    }
}
