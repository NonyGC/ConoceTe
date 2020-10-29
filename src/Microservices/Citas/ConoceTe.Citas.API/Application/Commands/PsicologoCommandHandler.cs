using ConoceTe.Citas.API.Infrastructure.Common;
using ConoceTe.Citas.Domain.AggregatesModel.CitasAggregate;
using ConoceTe.Citas.Infrastructure.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConoceTe.Citas.API.Application.Commands
{
    public class PsicologoCommandHandler :
        IRequestHandler<CrearPsicologoCommand, bool>,
        IRequestHandler<ActualizarPsicologoCommand, bool>,
        IRequestHandler<EliminarPsicologoCommand, bool>
    {
        private readonly IPsicologoRepository _psicologoRepository;
        private readonly IIdentityService _identityService;
        private readonly IMediator _mediator;
        private readonly ILogger<PacienteCommandHandler> _logger;

        public PsicologoCommandHandler(IPsicologoRepository psicologoRepository, IIdentityService identityService, IMediator mediator, ILogger<PacienteCommandHandler> logger)
        {
            _psicologoRepository = psicologoRepository ?? throw new ArgumentNullException(nameof(psicologoRepository));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CrearPsicologoCommand request, CancellationToken cancellationToken)
        {
            var psicologo = new Psicologo(request.Apellidos, request.Nombres, request.Direccion, request.FechaNacimiento.ToDateTime(Constant.FORMAT_DDMMYYYY), request.CuentaDeposito, request.GradoTitulacion, request.Especialidad, request.Estado);
            psicologo.EstadoActivo();

            _logger.LogInformation("----- Creando Psicologo - Psicologo: {@psicologo}", psicologo);

            _psicologoRepository.Add(psicologo);

            return await _psicologoRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }

        public async Task<bool> Handle(ActualizarPsicologoCommand request, CancellationToken cancellationToken)
        {
            var psicologo = new Psicologo(request.PsicologoId, request.Apellidos, request.Nombres, request.Direccion, request.FechaNacimiento.ToDateTime(Constant.FORMAT_DDMMYYYY), request.CuentaDeposito, request.GradoTitulacion, request.Especialidad, request.Estado);
            psicologo.EstadoActivo();

            _logger.LogInformation("----- Actualizando Psicologo - Psicologo: {@psicologo}", psicologo);

            _psicologoRepository.Update(psicologo);

            return await _psicologoRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }

        public async Task<bool> Handle(EliminarPsicologoCommand request, CancellationToken cancellationToken)
        {
            _psicologoRepository.Remove(request.PsicologoId);

            return await _psicologoRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }
    }
}
