using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SucursalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SucursalController(IMediator mediator)
        {
            _mediator = mediator;

        }

        /// <summary>
        /// Agrega registro de una sucursal.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(CreateSucursalCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Consulta de sucursal en base a su id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetSucursalByIdQuery { SucursalID = id }));
        }

    }
}
