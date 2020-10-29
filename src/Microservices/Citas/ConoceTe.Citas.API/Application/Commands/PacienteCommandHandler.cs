using ConoceTe.Citas.API.Infrastructure.Common;
using ConoceTe.Citas.Domain.AggregatesModel.CitasAggregate;
using ConoceTe.Citas.Infrastructure.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConoceTe.Citas.API.Application.Commands
{
    public class PacienteCommandHandler :
        IRequestHandler<CrearPacienteCommand, bool>,
        IRequestHandler<ActualizarPacienteCommand, bool>,
        IRequestHandler<EliminarPacienteCommand, bool>
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IIdentityService _identityService;
        private readonly IMediator _mediator;
        private readonly ILogger<PacienteCommandHandler> _logger;

        public PacienteCommandHandler(IPacienteRepository pacienteRepository, IIdentityService identityService, IMediator mediator, ILogger<PacienteCommandHandler> logger)
        {
            _pacienteRepository = pacienteRepository ?? throw new ArgumentNullException(nameof(pacienteRepository));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CrearPacienteCommand request, CancellationToken cancellationToken)
        {
            var paciente = new Paciente(request.Apellidos, request.Nombres, request.Direccion, request.FechaNacimiento.ToDateTime(Constant.FORMAT_DDMMYYYY));
            paciente.EstadoActivo();

            _logger.LogInformation("----- Creando Paciente - Paciente: {@paciente}", paciente);

            _pacienteRepository.Add(paciente);

            return await _pacienteRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }

        public async Task<bool> Handle(ActualizarPacienteCommand request, CancellationToken cancellationToken)
        {
            var paciente = new Paciente(request.PacienteId, request.Apellidos, request.Nombres, request.Direccion,request.FechaNacimiento.ToDateTime(Constant.FORMAT_DDMMYYYY));
            paciente.EstadoActivo();

            _logger.LogInformation("----- Actualizando Paciente - Paciente: {@paciente}", paciente);

            _pacienteRepository.Update(paciente);

            return await _pacienteRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }


        public async Task<bool> Handle(EliminarPacienteCommand request, CancellationToken cancellationToken)
        {
            _pacienteRepository.Remove(request.PacienteId);

            return await _pacienteRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
