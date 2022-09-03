using MediatR;
using Teste.Business.Models;

namespace Teste.Business.Commands.Produto
{
    public class ProdutoQuery : IRequest<ProdutoModel>
    {
        public Guid Id { get; }

        public ProdutoQuery(Guid id)
        {
            Id = id;
        }
    }
}