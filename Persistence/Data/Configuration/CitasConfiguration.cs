using System.Collections.Immutable;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Persistence.Data.Configuration;

public class CitasConfiguration : IEntityTypeConfiguration<Citas>
{
    public void Configure(EntityTypeBuilder<Citas> Builder){
        Builder.ToTable("cita");

        Builder.Property(e => e.Motivo)
        .HasColumnName("motivo")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(40);

        Builder.Property(e => e.Fecha)
        .IsRequired()
        .HasColumnName("fecha")
        .HasColumnType("date");

        Builder.Property(e => e.Hora)
        .IsRequired()
        .HasColumnName("hora")
        .HasColumnType("time");
        
        Builder.HasOne(e => e.Veterinario)
        .WithMany(e => e.Citas)
        .HasForeignKey(e => e.IdVeterinario);

        Builder.HasOne(e => e.Mascota)
        .WithMany(e => e.Citas)
        .HasForeignKey(e => e.IdMascotaFk);
    }
}
