using ConoceTe.Citas.Domain.AggregatesModel.CitasAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConoceTe.Citas.Infrastructure.EntityConfigurations
{
    public class PacienteEntityTypeConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Paciente", CitasContext.DEFAULT_SCHEMA);
            builder.HasKey(o => o.Id);
        }
    }
}
