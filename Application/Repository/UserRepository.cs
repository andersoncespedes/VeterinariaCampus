using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Persistence.Data;

namespace Application.Repository;
public class UserRepository : GenericRepository<Usuario>
{
    public UserRepository(APIContext context) : base(context)
    {
    }
}