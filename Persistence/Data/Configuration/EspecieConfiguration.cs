using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class EspecieConfiguration : IEntityTypeConfiguration<Especie>
{
    public void Configure(EntityTypeBuilder<Especie> builder)
    {
       builder.ToTable("especie");

       builder.Property(e => e.Nombre)
       .HasColumnName("nombre")
       .HasColumnType("varchar")
       .IsRequired()
       .HasMaxLength(30);

    }
}
