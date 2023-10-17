using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interface;
public interface IUnitOfWork
{
    public IMedicamento Medicamentos { get; }
    public IMovimientoMedicamento MovimientoMedicamentos { get; }
    public IProveedor Proveedores { get; }
    public IEspecie Especies { get; }
    public IMascota Mascotas { get; }
    public ITratamientoMedico TratamientosMedicos { get; }
    public IPropietario Propietarios { get; }
    public ICita Citas { get; }
    public IUser Users { get; }
    public IRol Rols { get; }
    public IDetalleMovimiento DetalleMovimientos { get; }
    public ILaboratorio Laboratorios { get; }
    public IVeterinario Veterinarios { get; }
    public IRaza Razas {get;}
    public Task<int> SaveAsync();
}
