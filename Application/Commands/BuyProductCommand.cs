using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class BuyProductCommand : IRequest<int>
    {
        public int ProductoID { get; set; }

        public int SucursalID { get; set; }

        public int CantidadComprada { get; set; }

        public class BuyProductCommandHandler : IRequestHandler<BuyProductCommand, int>
        {
            private readonly ApplicationContext _context;

            public BuyProductCommandHandler(ApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(BuyProductCommand command, CancellationToken cancellationToken)
            {
                // Obtener producto
                var stock = _context.Stock.FindAsync(command.ProductoID, command.SucursalID).Result;

                stock.Cantidad -= command.CantidadComprada;

                await _context.SaveChangesAsync();
       
                // El tipo de dato retornado debera ser igual al declarado en la interface IRequestHandler
                return stock.ProductoID;
            }
        }
    }
}
