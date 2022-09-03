using MediatR;

namespace Teste.Business.Commands.Produto
{
    public class AdicionarProdutoCommand : IRequest<Guid>
    {
        public string? Descricao { get; set; }
        public Guid CategoriaId { get; set; }
        public decimal Valor { get; set; }
    }
}