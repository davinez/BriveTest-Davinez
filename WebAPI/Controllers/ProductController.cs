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
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;

        }

        /// <summary>
        /// Agrega registro de producto.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Consulta de todos los productos existentes.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllProductsQuery()));
        }

        /// <summary>
        /// Consulta de producto en base a su id.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery { ProductoID = id }));
        }

        /// <summary>
        /// Actualizar registro de producto.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        {
            command.Id = id;

            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Borrado logico de producto.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Envio de notificaciones cuando producto ya no este disponible
            await _mediator.Publish(new Application.Notifications.DeleteProductNotification { ProductoID = id });

            return Ok(await _mediator.Send(new DeleteProductByIdCommand { ProductoID = id }));
        }
    }
}
