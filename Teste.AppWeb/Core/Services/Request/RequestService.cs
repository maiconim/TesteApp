namespace Teste.AppWeb.Core.Services.Request
{
    public class RequestService : IRequestService
    {
        private readonly Uri _baseUrl;

        public RequestService(IConfiguration configuration)
        {
            _baseUrl = new Uri(configuration["AppTestApi"]);
        }

        public async Task<string?> GetAsync(string url,CancellationToken cancellationToken = default)
        {
            using var client = CreateClient();
            var response = await client.GetAsync(url, cancellationToken);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Falha {(int)response.StatusCode}-{response.StatusCode} ao acessar ao solicitar ao recurso {client.BaseAddress}{url}");
            return await response.Content.ReadAsStringAsync();
        }

        public Task<TResponse> Post<TRequest, TResponse>(string url, TRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        private HttpClient CreateClient()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (request, message, cetChain, policyErrors) => true;

            var client =
                new HttpClient(handler, true)
                {
                    BaseAddress = _baseUrl
                };
            client.DefaultRequestHeaders.Add("accept", "*/*");

            return client;
        }
    }
}