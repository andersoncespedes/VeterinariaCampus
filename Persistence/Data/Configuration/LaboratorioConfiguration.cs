
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class LaboratorioConfiguration : IEntityTypeConfiguration<Laboratorio>
{
    public void Configure(EntityTypeBuilder<Laboratorio> builder)
    {
        builder.ToTable("laboratorio");

        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(30);

        builder.Property(e => e.Direccion)
        .HasColumnName("direccion")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(70);

        builder.Property(e => e.Telefono)
        .HasColumnName("telefono")
        .HasColumnType("int")
        .IsRequired();
    }
}
