using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interface;

namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    public IMedicamento Medicamentos => throw new NotImplementedException();

    public IProveedor Proveedores => throw new NotImplementedException();

    public IMascota Mascotas => throw new NotImplementedException();

    public ITratamientoMedico TratamientosMedicos => throw new NotImplementedException();

    public IPropietario Propietarios => throw new NotImplementedException();

    public ICita Citas => throw new NotImplementedException();

    public IDetalleMovimiento DetalleMovimientos => throw new NotImplementedException();

    public IUser Users => throw new NotImplementedException();

    public IRol Rols => throw new NotImplementedException();

    public Task<int> SaveAsync()
    {
        throw new NotImplementedException();
    }
}
