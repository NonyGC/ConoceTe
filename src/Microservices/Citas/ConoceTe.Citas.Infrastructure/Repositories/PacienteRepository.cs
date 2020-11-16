using ConoceTe.Citas.Domain.AggregatesModel.CitasAggregate;
using ConoceTe.Citas.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConoceTe.Citas.Infrastructure.Repositories
{
    public class PacienteRepository : RepositoryBase<Paciente>, IPacienteRepository
    {
        public PacienteRepository(CitasContext context) : base(context)
        {
        }
    }
}
