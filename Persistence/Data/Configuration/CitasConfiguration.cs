using System.Collections.Immutable;
using System;
using Microsoft.EntityFrameWorkCore.Metadata.Builders;
using Microsoft.EntityFrameWorkCore;
using AppDomain.Entities;
namespace Persistence.Data.Configuration;

public class CitasConfiguration : IEntityTypeConfiguration<Citas>
{
    public void Configure(EntityTypeBuilder<Citas> Builder){
        Builder.Property(e => e.);
    }
}
