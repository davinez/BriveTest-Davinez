using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        public async Task<IActionResult> CheckStockOfProduct(int productoID)
        {
            return Ok(await _mediator.Send(new CheckStockOfProductQuery { ProductoID = productoID }));
        }

        [HttpPost]
        public async Task<IActionResult> BuyProduct(BuyProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
