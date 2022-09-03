namespace Teste.Business.Models
{
    public class ProdutoModel
    {
        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public Guid CategoriaId { get; private set; }
        public string? CategoriaNome { get; private set; }
        public decimal Valor { get; private set; }

        public ProdutoModel(Guid id, string descricao, Guid categoriaId, decimal valor)
        {
            Id = id;
            Descricao = descricao;
            CategoriaId = categoriaId;
            Valor = valor;
        }

        public ProdutoModel(Guid id, string descricao, Guid categoriaId, string? categoriaNome, decimal valor) :
            this(id, descricao, categoriaId, valor)
        {
            CategoriaNome = categoriaNome;
        }
    }
}