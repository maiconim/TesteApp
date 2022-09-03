using Teste.Business.Models;

namespace Teste.Business.Services
{
    public interface IProdutoService
    {
        Task<Guid> AdicionarOuAlterarAsync(ProdutoModel produto, CancellationToken cancellationToken = default);
        Task ApagarAsync(Guid id, CancellationToken cancellationToken = default);
    }
}