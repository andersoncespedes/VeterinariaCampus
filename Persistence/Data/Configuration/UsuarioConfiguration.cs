using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuario");

        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.Correo)
        .HasColumnName("correo")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(40);

        builder.Property(e => e.Contraseña)
        .HasColumnName("contraseña")
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(255);

        builder.HasMany(e => e.Roles)
        .WithMany(e => e.Usuarios)
        .UsingEntity<RolesUsuarios>(
            j => j.HasOne(e => e.Rol)
            .WithMany(e => e.RolesUsuarios)
            .HasForeignKey(e => e.IdRolFk),

            j => j.HasOne(e => e.Usuario)
            .WithMany(e => e.RolesUsuarios)
            .HasForeignKey(e => e.IdUserFk),

            j =>
            {
                j.ToTable("usuarios_roles");
                j.HasKey(x => new { x.IdUserFk, x.IdRolFk });
            }
        );
    }
}
