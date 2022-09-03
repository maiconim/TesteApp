using Teste.Business.Models;

namespace Teste.Business.Services
{
    public interface ICategoriaService
    {
        Task<Guid> IncluirOuAlterarAsync(CategoriaModel categoria, CancellationToken cancellationToken=default);
        Task ApagarAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
