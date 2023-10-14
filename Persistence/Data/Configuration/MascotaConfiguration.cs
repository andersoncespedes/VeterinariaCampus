using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class MascotaConfiguration : IEntityTypeConfiguration<Mascota>
{
    public void Configure(EntityTypeBuilder<Mascota> builder)
    {
        builder.ToTable("mascota");

        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(40);

        builder.Property(e => e.FechaNacimiento)
        .HasColumnName("fecha_nacimiento")
        .HasColumnType("date")
        .IsRequired();

        builder.HasOne(e => e.Propietario)
        .WithMany(e => e.Mascotas)
        .HasForeignKey(e => e.IdPropietarioFk);

        builder.HasOne(e => e.Especie)
        .WithMany(e => e.Mascotas)
        .HasForeignKey(e => e.IdEspecieFk);

        builder.HasOne(e => e.Raza)
        .WithMany(e => e.Mascotas)
        .HasForeignKey(e => e.IdRazaFk);
    }
}
