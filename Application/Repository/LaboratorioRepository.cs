using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;
public class LaboratorioRepository : GenericRepository<Laboratorio>, ILaboratorio
{
    public LaboratorioRepository(APIContext context) : base(context)
    {
    }
}
