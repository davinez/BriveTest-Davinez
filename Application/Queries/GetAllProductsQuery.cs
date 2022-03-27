using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Producto>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Producto>>
        {
            private readonly ApplicationContext _context;

            public GetAllProductsQueryHandler(ApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Producto>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Producto.ToListAsync();

                // El tipo de dato retornado debera ser igual al declarado en la interface IRequest
                return productList;
            }
        }
    }
}
