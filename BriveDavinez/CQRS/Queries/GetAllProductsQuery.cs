using BriveDavinez.Context;
using BriveDavinez.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BriveDavinez.CQRS.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Producto>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Producto>>
        {
            private readonly BriveDavinezContext _context;

            public GetAllProductsQueryHandler(BriveDavinezContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Producto>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Producto.ToListAsync();

                // El tipo de dato retornado debera ser igual al declarado en la interface IRequestHandler
                return productList;
            }
        }
    }
}
