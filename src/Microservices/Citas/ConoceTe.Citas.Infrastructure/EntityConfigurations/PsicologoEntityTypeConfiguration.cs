using ConoceTe.Citas.Domain.AggregatesModel.CitasAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConoceTe.Citas.Infrastructure.EntityConfigurations
{
    public class PsicologoEntityTypeConfiguration : IEntityTypeConfiguration<Psicologo>
    {
        public void Configure(EntityTypeBuilder<Psicologo> builder)
        {
            builder.ToTable("Psicologo", CitasContext.DEFAULT_SCHEMA);
            builder.HasKey(o => o.Id);
        }
    }
}
