using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class CheckStockOfProductQuery : IRequest<IEnumerable<StockOfProduct>>
    {
        public int ProductoID { get; set; }

        public class CheckStockOfProductQueryHandler : IRequestHandler<CheckStockOfProductQuery, IEnumerable<StockOfProduct>>
        {
            private readonly ApplicationContext _context;

            public CheckStockOfProductQueryHandler(ApplicationContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<StockOfProduct>> Handle(CheckStockOfProductQuery query, CancellationToken cancellationToken)
            {
                // Obtener lista de objeto definido y no un tipo anonimo
                var stockOfProductList = await (from sucursal in _context.Sucursal
                                          join stock in _context.Stock on sucursal.SucursalID equals stock.SucursalID
                                          where stock.ProductoID == query.ProductoID
                                          select new StockOfProduct
                                          {
                                              Nombre = sucursal.Nombre,
                                              Cantidad = stock.Cantidad,
                                              Precio = stock.Precio,
                                          }).ToListAsync();

                // El tipo de dato retornado debera ser igual al declarado en la interface IRequestHandler
                return stockOfProductList;
            }
        }
    }
}
