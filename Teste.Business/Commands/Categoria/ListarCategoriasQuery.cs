using MediatR;
using Teste.Business.Models;

namespace Teste.Business.Commands.Categoria
{
    public class ListarCategoriasQuery : GenericPaginatedRequestQuery, IRequest<GenericPaginatedResultQuery<CategoriaModel>>
    {
    }
}