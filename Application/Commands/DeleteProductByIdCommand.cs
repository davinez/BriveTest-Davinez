using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class DeleteProductByIdCommand : IRequest<int>
    {
        public int ProductoID { get; set; }

        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
        {
            private readonly ApplicationContext _context;

            public DeleteProductByIdCommandHandler(ApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await _context.Producto.Where(a => a.ProductoID == command.ProductoID).FirstOrDefaultAsync();
                _context.Producto.Remove(product);

                await _context.SaveChangesAsync();

                // El tipo de dato retornado debera ser igual al declarado en la interface IRequestHandler
                return product.ProductoID;
            }
        }
    }
}
