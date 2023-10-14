using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
{
    public void Configure(EntityTypeBuilder<Medicamento> builder)
    {
        builder.ToTable("medicamento");

        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .HasMaxLength(40)
        .IsRequired();

        builder.Property(e => e.CantidadDisponible)
        .HasColumnName("cantidad_disponible")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(40);

        builder.Property(e => e.Precio)
        .HasColumnName("precion")
        .HasColumnType("double")
        .HasPrecision(2,6)
        .IsRequired();

        builder.HasMany(e => e.Proveedores)
        .WithMany(e => e.Medicamentos)
        .UsingEntity<MedicamentoProveedores>(
            j => j.HasOne(e => e.Proveedor)
            .WithMany(e => e.MedicamentoProveedores),

            j => j.HasOne(e => e.Medicamento)
            .WithMany(e => e.MedicamentoProveedores),

            j => {
                j.ToTable("medicamento_proveedor");
                j.HasIndex(e => new {e.IdProveedorFk, e.IdMedicamentoFk});
            }
        );
    }
}
