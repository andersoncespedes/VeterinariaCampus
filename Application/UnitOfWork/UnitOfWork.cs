
using Application.Repository;
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
    private LaboratorioRepository _laboratorio;
    private MovimientoMedicamentoRepository _movMed;
    private VeterinarioRepository _veterinario;
    private EspecieRepository _especie;
    private RazaRepository _razas;
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

    public ILaboratorio Laboratorios
    {
        get
        {
            _laboratorio ??= new(_context);
            return _laboratorio;
        }
    }

    public IMovimientoMedicamento MovimientoMedicamentos
    {
        get
        {
            _movMed ??= new(_context);
            return _movMed;
        }
    }

    public IVeterinario Veterinarios
    {
        get
        {
            _veterinario ??= new(_context);
            return _veterinario;
        }
    }

    public IEspecie Especies
    {
        get
        {
            _especie ??= new(_context);
            return _especie;
        }
    }

    public IRaza Razas {
        get{
            _razas ??= new(_context);
            return _razas;
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
