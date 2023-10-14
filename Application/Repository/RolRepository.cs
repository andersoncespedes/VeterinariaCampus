using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Persistence.Data;

namespace Application.Repository;
public class RolRepository : GenericRepository<Rol>
{
    public RolRepository(APIContext context) : base(context)
    {
    }
}
