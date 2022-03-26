using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Notifications
{
    public class DeleteProductNotification : INotification
    {
        public int ProductoID { get; set; }
    }

    public class EmailHandler : INotificationHandler<DeleteProductNotification>
    {
        // Envio de Email a departamento de compras
        public Task Handle(DeleteProductNotification notification, CancellationToken cancellationToken)
        {
            int id = notification.ProductoID;

            // Placeholder - Envio de email
            Debug.WriteLine("Enviando email...");

            return Task.CompletedTask;
        }
    }

    public class SMSHandler : INotificationHandler<DeleteProductNotification>
    {
        // Envio de SMS a clientes
        public Task Handle(DeleteProductNotification notification, CancellationToken cancellationToken)
        {
            int id = notification.ProductoID;

            // Placeholder - Envio de SMS
            Debug.WriteLine("Enviando SMS...");


            return Task.CompletedTask;
        }
    }
}
