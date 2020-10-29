using ConoceTe.Citas.API.Application.Commands;
using ConoceTe.Citas.API.Infrastructure.Common;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConoceTe.Citas.API.Application.Validations
{
    public class PacienteValidator
    {
    }

    public class CrearPacienteCommadVidator: AbstractValidator<CrearPacienteCommand>
    {
        public CrearPacienteCommadVidator()
        {
            RuleFor(command => command.Apellidos).NotEmpty().WithMessage("Falta ingresar Apellidos");
            RuleFor(command => command.Nombres).NotEmpty().WithMessage("Falta ingresar Nombres");
            RuleFor(command => command.Direccion).NotEmpty().WithMessage("Falta ingresar Dirección");
            RuleFor(command => command.FechaNacimiento).Must(GenericFunctions.BeAValidDate).WithMessage("Fecha nacimiento inválido"); ;
        }
    }

    public class ActualizarPacienteCommadVidator : AbstractValidator<ActualizarPacienteCommand>
    {
        public ActualizarPacienteCommadVidator()
        {
            RuleFor(command => command.PacienteId).NotNull().WithMessage("Código del paciente inválido");
            RuleFor(command => command.Apellidos).NotEmpty().WithMessage("Falta ingresar Apellidos");
            RuleFor(command => command.Nombres).NotEmpty().WithMessage("Falta ingresar Nombres");
            RuleFor(command => command.Direccion).NotEmpty().WithMessage("Falta ingresar Dirección");
            RuleFor(command => command.FechaNacimiento).Must(GenericFunctions.BeAValidDate).WithMessage("Fecha nacimiento inválido"); ;
        }
    }
    
    public class EliminarPacienteCommadVidator : AbstractValidator<ActualizarPacienteCommand>
    {
        public EliminarPacienteCommadVidator()
        {
            RuleFor(command => command.PacienteId).NotNull().WithMessage("Código del paciente inválido");
        }
    }


}
