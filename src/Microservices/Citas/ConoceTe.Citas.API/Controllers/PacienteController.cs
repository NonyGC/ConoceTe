using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ConoceTe.Citas.API.Application.Commands;
using ConoceTe.Citas.Domain.AggregatesModel.CitasAggregate;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConoceTe.Citas.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMediator _mediator;
        private readonly ILogger<PacienteController> _logger;

        public PacienteController(IPacienteRepository pacienteRepository, IMediator mediator, ILogger<PacienteController> logger)
        {
            _pacienteRepository = pacienteRepository ?? throw new ArgumentNullException(nameof(pacienteRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Paciente>), 200)]
        [Route("get")]
        public IEnumerable<Paciente> Get()
        {
            return _pacienteRepository.GetAll().ToList();
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Paciente), 400)]
        [Route("get/{id}")]
        public Paciente Get(int id)
        {
            return _pacienteRepository.GetById(id);
        }

        // POST: api/Paciente
        [Route("Crear")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CrearPacienteAsync([FromBody] CrearPacienteCommand command)
        {
            bool commandResult = await _mediator.Send(command);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        [Route("actualizar")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ActualizarPacienteAsync([FromBody] ActualizarPacienteCommand command)
        {

            bool commandResult = await _mediator.Send(command);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("eliminar/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> EliminarPacienteAsync(int id)
        {
            var command = new EliminarPacienteCommand(id);
            bool commandResult = await _mediator.Send(command);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
