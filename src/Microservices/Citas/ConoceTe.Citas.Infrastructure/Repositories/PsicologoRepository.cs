using ConoceTe.Citas.Domain.AggregatesModel.CitasAggregate;
using ConoceTe.Citas.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConoceTe.Citas.Infrastructure.Repositories
{
    public class PsicologoRepository : RepositoryBase<Psicologo>, IPsicologoRepository
    {
        public PsicologoRepository(CitasContext context) : base(context)
        {

        }

        public IUnitOfWork UnitOfWork => Context;
    }
}
