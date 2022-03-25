using BriveDavinez.Context;
using BriveDavinez.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BriveDavinez.CQRS.Queries
{
    public class GetProductByIdQuery : IRequest<Producto>
    {
        public int ProductoID { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Producto>
        {
            private readonly BriveDavinezContext _context;

            public GetProductByIdQueryHandler(BriveDavinezContext context)
            {
                _context = context;
            }

            public async Task<Producto> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _context.Producto.Where(a => a.ProductoID == query.ProductoID).FirstOrDefaultAsync();

                // El tipo de dato retornado debera ser igual al declarado en la interface IRequestHandler
                return product;
            }
        }
    }
}
