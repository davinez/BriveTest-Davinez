using Infrastructure.HttpClients;
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

    // Email
    public class EmailHandler : INotificationHandler<DeleteProductNotification>
    {
        private readonly IAcmeClient _acmeClient;

        public EmailHandler(IAcmeClient acmeClient)
        {
            _acmeClient = acmeClient;
        }

        // Envio de Email a departamento de compras
        public Task Handle(DeleteProductNotification notification, CancellationToken cancellationToken)
        {
            int id = notification.ProductoID;

            // Placeholder - Envio de email
            Debug.WriteLine("Enviando email...");

            _acmeClient.SendEmail("email", "body");

            return Task.CompletedTask;

        }
    }

    // SMS
    public class SMSHandler : INotificationHandler<DeleteProductNotification>
    {
        private readonly IAcmeClient _acmeClient;

        public SMSHandler(IAcmeClient acmeClient)
        {
            _acmeClient = acmeClient;
        }

        // Envio de SMS a clientes
        public Task Handle(DeleteProductNotification notification, CancellationToken cancellationToken)
        {
            int id = notification.ProductoID;

            // Placeholder - Envio de SMS
            Debug.WriteLine("Enviando SMS...");

            _acmeClient.SendSMS("number", "body");

            return Task.CompletedTask;
        }

    }
}
