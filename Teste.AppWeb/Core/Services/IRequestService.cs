namespace Teste.AppWeb.Core.Services
{
    public interface IRequestService
    {
        Task<string?> GetAsync(string url, CancellationToken cancellationToken = default);
        Task<TResponse> Post<TRequest, TResponse>(string url, TRequest request, CancellationToken cancellationToken = default);
    }
}