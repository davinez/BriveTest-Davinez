using Infrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public string Nombre { get; set; }

        public string Marca { get; set; }

        public string CodigoDeBarras { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private readonly ApplicationContext _context;

            public UpdateProductCommandHandler(ApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var producto = _context.Producto.Where(a => a.ProductoID == command.Id).FirstOrDefault();

                if (producto == null)
                {
                    return default;
                }
                else
                {
                    producto.Descripcion = command.Descripcion;
                    producto.Nombre = command.Nombre;
                    producto.Marca = command.Marca;
                    producto.CodigoDeBarras = command.CodigoDeBarras;


                    await _context.SaveChangesAsync();

                    // El tipo de dato retornado debera ser igual al declarado en la interface IRequestHandler
                    return producto.ProductoID;
                }
            }
        }
    }
}
