using Domain.Entities;
using Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateSucursalCommand : IRequest<int>
    {
        // Datos requeridos para ejecutar el comando
        public string Nombre { get; set; }

        public string Ubicacion { get; set; }
  
        public class CreateSucursalCommandHandler : IRequestHandler<CreateSucursalCommand, int>
        {
            private readonly ApplicationContext _context;

            public CreateSucursalCommandHandler(ApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateSucursalCommand command, CancellationToken cancellationToken)
            {
                var sucursal = new Sucursal
                {                 
                    Nombre = command.Nombre,
                    Ubicacion = command.Ubicacion,                 
                };

                _context.Sucursal.Add(sucursal);
                await _context.SaveChangesAsync();

                // El tipo de dato retornado debera ser igual al declarado en la interface IRequest
                return sucursal.SucursalID;
            }
        }

    }
}
