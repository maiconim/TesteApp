using MediatR;
using Teste.Business.Models;

namespace Teste.Business.Commands.Produto
{
    public class ListarProdutoQuery :GenericPaginatedRequestQuery, IRequest<GenericPaginatedResultQuery<ProdutoModel>>
    {
        public string? PorDescricao { get; set; }
    }
}