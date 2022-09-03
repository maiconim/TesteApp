using MediatR;

namespace Teste.Business.Commands.Categoria
{
    public class AtualizarCategoriaCommand : IRequest
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
    }
}