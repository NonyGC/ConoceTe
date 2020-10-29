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


        // GET: api/Paciente
        [HttpGet]
        public IEnumerable<Paciente> Get()
        {
            return _pacienteRepository.GetAll().ToList();
        }

        // GET: api/Paciente/5
        [HttpGet("{id}", Name = "Get")]
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

        // PUT: api/Paciente/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
