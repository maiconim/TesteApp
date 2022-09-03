using Teste.Business.Core.Entity;
using Teste.Business.DomainServices;

namespace Teste.Business.Entities
{
    internal class CategoriaEntity : BaseEntity
    {
        public string Nome { get; protected set; } = string.Empty;

        protected CategoriaEntity() { }
        public CategoriaEntity(string nome, ICategoriaDomainService domainService) : this()
        {
            AlterarNome(nome, domainService);
        }

        public CategoriaEntity AlterarNome(string nome, ICategoriaDomainService domainService)
        {
            AlterarNomeAsync(nome, domainService).Wait();
            return this;
        }

        public async Task<CategoriaEntity> AlterarNomeAsync(string nome, ICategoriaDomainService domainService)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new Exception("O nome da categoria deve ser informado.");
            if (nome.Trim().Length <= 3) throw new Exception("Informe um nome válido para a categoria.");
            if (await domainService.NomeJaUtilizadoAsync(this, nome)) throw new Exception($"O nome '{nome}' já está cadastrado.");

            Nome = nome;
            return this;
        }
    }
}