using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private MedicamentoRepository _medicamento;
    private ProveedorRepository _proveedor;
    private MascotaRepository _mascota;
    private TratamientoMedicoRepository _tratamiento;
    private PropietarioRepository _propietario;
    private CitaRepository _cita;
    private DetalleMovimientoRepository _detalleMov;
    private UserRepository _users;
    private RolRepository _roles;
    private readonly APIContext _context;
    public UnitOfWork(APIContext context)
    {
        _context = context;
    }
    public IMedicamento Medicamentos
    {
        get
        {
            _medicamento ??= new(_context);
            return _medicamento;
        }
    }

    public IProveedor Proveedores
    {
        get
        {
            _proveedor ??= new(_context);
            return _proveedor;
        }
    }

    public IMascota Mascotas
    {
        get
        {
            _mascota ??= new(_context);
            return _mascota;
        }
    }

    public ITratamientoMedico TratamientosMedicos
    {
        get
        {
            _tratamiento ??= new(_context);
            return _tratamiento;
        }
    }

    public IPropietario Propietarios
    {
        get
        {
            _propietario ??= new(_context);
            return _propietario;
        }
    }

    public ICita Citas
    {
        get
        {
            _cita ??= new(_context);
            return _cita;
        }
    }

    public IDetalleMovimiento DetalleMovimientos
    {
        get
        {
            _detalleMov ??= new(_context);
            return _detalleMov;
        }
    }

    public IUser Users
    {
        get
        {
            _users ??= new(_context);
            return _users;
        }
    }

    public IRol Rols
    {
        get
        {
            _roles ??= new(_context);
            return _roles;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
