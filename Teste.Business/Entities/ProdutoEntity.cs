using Microsoft.Extensions.Options;
using Teste.Business.Core.Entity;

namespace Teste.Business.Entities
{
    internal class ProdutoEntity : BaseEntity
    {
        public string Descricao { get; protected set; }
        public Guid CategoriaID { get; protected set; }
        public CategoriaEntity Categoria { get; protected set; }
        public decimal Valor { get; protected set; }

        protected ProdutoEntity() { }
        public ProdutoEntity(string descricao, CategoriaEntity categoria) : this()
        {
            Descricao = descricao;
            AlterarCategoria(categoria);
        }

        public ProdutoEntity AlterarDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao)) throw new Exception("Informe a descrição do produto.");
            if (descricao.Trim().Length <= 3) throw new Exception("A descrição do produto é inválida.");

            Descricao = descricao;

            return this;
        }

        public ProdutoEntity AlterarCategoria(CategoriaEntity categoria)
        {
            if (categoria == null) throw new Exception("A categoria deve ser informada.");
            if (categoria.Id == Guid.Empty) throw new Exception("Categoria não cadastrada.");

            Categoria = categoria;
            CategoriaID = categoria.Id;

            return this;
        }

        public ProdutoEntity AlterarValor(decimal valor)
        {
            if (valor < 0) throw new Exception("O valor do produto deve ser superior a zero.");

            Valor = valor;
            return this;
        }
    }
}