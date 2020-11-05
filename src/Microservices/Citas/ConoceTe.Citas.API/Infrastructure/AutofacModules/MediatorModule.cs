using System.Linq;
using System.Reflection;
using Autofac;
using ConoceTe.Citas.API.Application.Commands;
using ConoceTe.Citas.API.Application.Validations;
using FluentValidation;
using MediatR;

namespace ConoceTe.Citas.API.Infrastructure.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(CrearPacienteCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(ActualizarPacienteCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
            builder.RegisterAssemblyTypes(typeof(EliminarPacienteCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));


            builder
                .RegisterAssemblyTypes(typeof(CrearPacienteCommadVidator).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>))).AsImplementedInterfaces();
            builder
                .RegisterAssemblyTypes(typeof(ActualizarPacienteCommadVidator).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>))).AsImplementedInterfaces();
            builder
                .RegisterAssemblyTypes(typeof(EliminarPacienteCommadVidator).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>))).AsImplementedInterfaces();


            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

        }
    }
}
