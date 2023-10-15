using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;
public class EspecieRepository : GenericRepository<Especie>, IEspecie
{
    public EspecieRepository(APIContext context) : base(context)
    {
    }
}
