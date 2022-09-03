using MediatR;

namespace Teste.Business.Commands.Categoria
{
    public class ApagarCategoriaCommand : IRequest
    {
        public Guid Id { get; }

        public ApagarCategoriaCommand(Guid id)
        {
            Id = id;
        }
    }
}