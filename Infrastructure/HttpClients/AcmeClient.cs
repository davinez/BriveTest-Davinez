using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.HttpClients
{
    public class AcmeClientSettings
    {
        public string ApiKey { get; set; }

        public string BaseUrl { get; set; }

    }

    public interface IAcmeClient
    {
        Task<bool> SendEmail(string email, string body);

        Task<bool> SendSMS(string number, string body);
    }

    public class AcmeClient : IAcmeClient
    {
        private readonly HttpClient _client;
        private readonly AcmeClientSettings _settings;

        public AcmeClient(HttpClient client, AcmeClientSettings settings)
        {
            _client = client;
            _settings = settings;
            _client.BaseAddress = new Uri(_settings.BaseUrl);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> SendEmail(string email, string body)
        {
            // Consumo de servicio
            
            return true;
        }

        public async Task<bool> SendSMS(string numero, string body)
        {
            // Consumo de servicio

            return true;
        }


    }
}
