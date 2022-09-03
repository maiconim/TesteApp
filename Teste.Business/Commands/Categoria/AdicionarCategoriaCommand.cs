using MediatR;

namespace Teste.Business.Commands.Categoria
{
    public class AdicionarCategoriaCommand : IRequest<Guid>
    {
        public string Nome { get; set; } = string.Empty;
    }
}