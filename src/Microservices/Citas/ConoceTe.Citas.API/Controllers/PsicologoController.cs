using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ConoceTe.Citas.API.Application.Commands;
using ConoceTe.Citas.Domain.AggregatesModel.CitasAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConoceTe.Citas.API.Controllers
{
    public class PsicologoController : Controller
    {
        private readonly IPsicologoRepository _psicologoRepository;
        private readonly IMediator _mediator;
        private readonly ILogger<PsicologoController> _logger;

        public PsicologoController(IPsicologoRepository psicologoRepository, IMediator mediator, ILogger<PsicologoController> logger)
        {
            _psicologoRepository = psicologoRepository ?? throw new ArgumentNullException(nameof(psicologoRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Psicologo>), 200)]
        [Route("get")]
        public IActionResult Get()
        {
            var list = _psicologoRepository.GetAll().ToList();
            return Ok(list);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Psicologo), 400)]
        [Route("get/{id}")]
        public IActionResult Get(int id)
        {
            var psicologo= _psicologoRepository.GetById(id);
            return Ok(psicologo);
        }

        // POST: api/Psicologo
        [Route("Crear")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CrearPsicologoAsync([FromBody] CrearPsicologoCommand command)
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
        public async Task<IActionResult> ActualizarPsicologoAsync([FromBody] ActualizarPsicologoCommand command)
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
        public async Task<IActionResult> EliminarPsicologoAsync(int id)
        {
            var command = new EliminarPsicologoCommand(id);
            bool commandResult = await _mediator.Send(command);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
