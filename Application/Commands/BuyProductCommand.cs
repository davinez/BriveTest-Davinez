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
    public class BuyProductCommand : IRequest<bool>
    {
        public int ProductoID { get; set; }

        public int SucursalID { get; set; }

        public int CantidadComprada { get; set; }

        public class BuyProductCommandHandler : IRequestHandler<BuyProductCommand, bool>
        {
            private readonly ApplicationContext _context;

            public BuyProductCommandHandler(ApplicationContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(BuyProductCommand command, CancellationToken cancellationToken)
            {
                // Obtener producto
                var stock = _context.Stock.FindAsync(command.ProductoID, command.SucursalID).Result;

                // Stock insuficiente
                if (command.CantidadComprada > stock.Cantidad)
                {
                    return false;
                }
                
                stock.Cantidad -= command.CantidadComprada;

                await _context.SaveChangesAsync();

                // El tipo de dato retornado debera ser igual al declarado en la interface IRequest
                return true;

            }
        }
    }
}
