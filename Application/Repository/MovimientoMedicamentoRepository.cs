

using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;
public class MovimientoMedicamentoRepository : GenericRepository<MovimientoMedicamento>, IMovimientoMedicamento
{
    public MovimientoMedicamentoRepository(APIContext context) : base(context)
    {
    }
}
