using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class TratamientoMedicoConfiguration : IEntityTypeConfiguration<TratamientoMedico>
{
    public void Configure(EntityTypeBuilder<TratamientoMedico> builder)
    {
        builder.ToTable("tratamiento_medico");

        builder.HasOne(e => e.Citas)
        .WithMany(e => e.TratamientoMedicos)
        .HasForeignKey(e => e.IdCitaFk);

        builder.HasOne(e => e.Medicamento)
        .WithMany(e => e.TratamientoMedicos)
        .HasForeignKey(e => e.IdMedicamentoFk);

        builder.Property(e => e.Dosis)
        .HasColumnName("dosis")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(e => e.FechaAdministracion)
        .HasColumnName("fecha_administracion")
        .HasColumnType("date")
        .IsRequired();

        builder.Property(e => e.Observacion)
        .HasColumnName("observacion")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(50);
    }
}
