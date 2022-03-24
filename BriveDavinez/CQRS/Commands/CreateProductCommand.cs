using BriveDavinez.Context;
using BriveDavinez.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BriveDavinez.CQRS.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        // Datos requeridos para ejecutar el comando
        public string Descripcion { get; set; }
        public string Nombre { get; set; }

        public string Marca { get; set; }

        public string CodigoDeBarras { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private BriveDavinezContext _context;

            public CreateProductCommandHandler(BriveDavinezContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var producto = new Producto();
                producto.Descripcion = command.Descripcion;
                producto.Nombre = command.Nombre;
                producto.Marca = command.Marca;
                producto.CodigoDeBarras = command.CodigoDeBarras;

                _context.Producto.Add(producto);
                await _context.SaveChangesAsync();

                // El tipo de dato retornado debera ser igual al declarado en la interface IRequestHandler
                return producto.Id;
            }
        }
    }
}
