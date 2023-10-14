using System.Collections.Immutable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class DetalleMovimientoConfiguration : IEntityTypeConfiguration<DetalleMovimiento>
{
    public void Configure(EntityTypeBuilder<DetalleMovimiento> builder)
    {
        builder.ToTable("detalle_movimiento");
        builder.Property(e => e.Cantidad)
        .HasColumnType("int")
        .HasColumnName("cantidad")
        .IsRequired();

        builder.Property(e => e.Precio)
        .HasColumnName("precio")
        .HasColumnType("double")
        .HasPrecision(2,8)
        .IsRequired();

        builder.HasOne(e => e.Medicamento)
        .WithMany(e => e.DetalleMovimientos)
        .HasForeignKey(e => e.IdProductoFk);

        builder.HasOne(e => e.MovimientoMedicamento)
        .WithMany(e => e.DetalleMovimientos)
        .HasForeignKey(e => e.IdMovMedFk);
    }
}
