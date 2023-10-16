
using Domain.Entities;

namespace Domain.Interface;
public interface IProveedor : IGenericRepository<Proveedor>
{
    Task<IEnumerable<Proveedor>> GetPerMedicamento(string nombre);
}
