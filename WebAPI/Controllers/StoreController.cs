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
    public class StoreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator)
        {
            _mediator = mediator;

        }

        /// <summary>
        /// Revisa stock de un producto.
        /// </summary>            
        [HttpGet]
        public async Task<IActionResult> CheckStockOfProduct(int productoID)
        {
            return Ok(await _mediator.Send(new CheckStockOfProductQuery { ProductoID = productoID }));
        }

        /// <summary>
        /// Reduce cantidad del stock actual.
        /// </summary> 
        /// <response code="200">Operacion Exitosa</response>
        /// <response code="400">Stock insuficiente</response>        
        [HttpPost]
        public async Task<IActionResult> BuyProduct(BuyProductCommand command)
        {
            var commandResult = await _mediator.Send(command);

            // Stock insuficiente
            if (!commandResult)
            {
                return BadRequest();
            }

            // Operacion exitosa
            return Ok();
        }
    }
}
