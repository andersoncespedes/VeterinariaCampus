using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class MovimientoMedicamentoConfiguration : IEntityTypeConfiguration<MovimientoMedicamento>
{
    public void Configure(EntityTypeBuilder<MovimientoMedicamento> builder)
    {
        builder.ToTable("movimiento_medicamento");

        builder.Property(e => e.Fecha)
        .HasColumnName("fecha")
        .HasColumnType("date")
        .IsRequired();
        builder.HasOne(e => e.TipoMovimiento)
        .WithMany(e => e.MovimientoMedicamentos)
        .HasForeignKey(e => e.IdTipoMovFk);
    }
}
