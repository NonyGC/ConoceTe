using Autofac;
using ConoceTe.Citas.API.Application.Commands;
using ConoceTe.Citas.Domain.AggregatesModel.CitasAggregate;
using ConoceTe.Citas.Infrastructure.Repositories;
using ConoceTe.EvenBus.Abstractions;
using System.Reflection;

namespace ConoceTe.Citas.API.Infrastructure.AutofacModules
{

    public class ApplicationModule
        :Autofac.Module
    {

        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;

        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<PacienteRepository>()
                .As<IPacienteRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PsicologoRepository>()
                .As<IPsicologoRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(PacienteCommandHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));

        }
    }
}
