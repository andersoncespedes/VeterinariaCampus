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
        .HasColumnName("precio")
        .HasColumnType("double")
        .HasPrecision(2, 6)
        .IsRequired();

        builder.HasOne(e => e.Laboratorio)
        .WithMany(e => e.Medicamentos)
        .HasForeignKey(e => e.IdLaboratorioFk);

        builder.HasMany(e => e.Proveedores)
        .WithMany(e => e.Medicamentos)
        .UsingEntity<MedicamentoProveedores>(
            j => j.HasOne(e => e.Proveedor)
            .WithMany(e => e.MedicamentoProveedores)
            .HasForeignKey(e => e.IdProveedorFk),

            j => j.HasOne(e => e.Medicamento)
            .WithMany(e => e.MedicamentoProveedores)
            .HasForeignKey(e => e.IdMedicamentoFk),

            j =>
            {
                j.ToTable("medicamento_proveedor");
                j.HasKey(e => new { e.IdProveedorFk, e.IdMedicamentoFk });
            }
        );
    }
}
