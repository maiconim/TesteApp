using MediatR;

namespace Teste.Business.Commands.Produto
{
    public class ApagarProdutoCommand : IRequest
    {
        public Guid Id { get; }

        public ApagarProdutoCommand(Guid id)
        {
            Id = id;
        }
    }
}