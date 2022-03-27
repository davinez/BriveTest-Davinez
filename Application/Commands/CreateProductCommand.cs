using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
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
            private readonly ApplicationContext _context;

            public CreateProductCommandHandler(ApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var producto = new Producto
                {
                    Descripcion = command.Descripcion,
                    Nombre = command.Nombre,
                    Marca = command.Marca,
                    CodigoDeBarras = command.CodigoDeBarras
                };

                _context.Producto.Add(producto);
                await _context.SaveChangesAsync();

                // El tipo de dato retornado debera ser igual al declarado en la interface IRequest
                return producto.ProductoID;
            }
        }
    }
}
