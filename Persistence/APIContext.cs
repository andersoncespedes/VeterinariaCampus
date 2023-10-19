using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Persistence.Data;
public class APIContext : DbContext
{
    public DbSet<Citas> Citas { get; set; }
    public DbSet<DetalleMovimiento> DetallesMovimientos { get; set; }
    public DbSet<MedicamentoProveedores> MedicamentoProveedores { get; set; }

    public DbSet<Especie> Especies { get; set; }
    public DbSet<Laboratorio> Laboratorios { get; set; }
    public DbSet<Mascota> Mascotas { get; set; }
    public DbSet<Medicamento> Medicamentos { get; set; }
    public DbSet<MovimientoMedicamento> MovimientosMedicamentos { get; set; }
    public DbSet<Propietario> Propietarios { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<Raza> Razas { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<TipoMovimiento> TiposMovimientos { get; set; }
    public DbSet<TratamientoMedico> TratamientosMedicos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Veterinario> Veterinarios { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public APIContext(DbContextOptions<APIContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
