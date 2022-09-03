using MediatR;

namespace Teste.Business.Commands.Produto
{
    public class AlterarProdutoCommand : IRequest
    {
        public Guid Id { get; set; }
        public string? Descricao { get; set; }
        public Guid CategoriaID { get; set; }
        public decimal Valor { get; set; }
    }
}