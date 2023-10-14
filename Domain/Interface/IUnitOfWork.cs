using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interface;
public interface IUnitOfWork
{
    public IMedicamento Medicamentos { get; }
    public IProveedor Proveedores { get; }
    public IMascota Mascotas { get; }
    public ITratamientoMedico TratamientosMedicos { get; }
    public IPropietario Propietarios { get; }
    public ICita Citas { get; }
    public IDetalleMovimiento DetalleMovimientos { get; }
    public Task<int> SaveAsync();
}
