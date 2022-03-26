using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetSucursalByIdQuery : IRequest<Sucursal>
    {
        public int SucursalID { get; set; }

        public class GetSucursalByIdQueryHandler : IRequestHandler<GetSucursalByIdQuery, Sucursal>
        {
            private readonly ApplicationContext _context;

            public GetSucursalByIdQueryHandler(ApplicationContext context)
            {
                _context = context;
            }

            public async Task<Sucursal> Handle(GetSucursalByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _context.Sucursal.Where(a => a.SucursalID == query.SucursalID).FirstOrDefaultAsync();

                // El tipo de dato retornado debera ser igual al declarado en la interface IRequestHandler
                return product;
            }
        }

    }
}
