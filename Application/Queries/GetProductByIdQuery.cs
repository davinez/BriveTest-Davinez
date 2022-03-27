using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetProductByIdQuery : IRequest<Producto>
    {
        public int ProductoID { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Producto>
        {
            private readonly ApplicationContext _context;

            public GetProductByIdQueryHandler(ApplicationContext context)
            {
                _context = context;
            }

            public async Task<Producto> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _context.Producto.Where(a => a.ProductoID == query.ProductoID).FirstOrDefaultAsync();

                // El tipo de dato retornado debera ser igual al declarado en la interface IRequest
                return product;
            }
        }
    }
}
