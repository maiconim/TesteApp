using Teste.Business.Entities;

namespace Teste.Business.DomainServices
{
    internal interface ICategoriaDomainService
    {
        Task<bool> NomeJaUtilizadoAsync(CategoriaEntity categoria, string nome);
    }
}
