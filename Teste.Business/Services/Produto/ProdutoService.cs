using Microsoft.EntityFrameworkCore;
using System.Threading;
using Teste.Business.Core.Context;
using Teste.Business.Entities;
using Teste.Business.Models;

namespace Teste.Business.Services.Produto
{
    internal class ProdutoService : IProdutoService
    {
        private readonly TesteAppContext _context;
        private readonly DbSet<ProdutoEntity> _set;
        private readonly DbSet<CategoriaEntity> _categoriaSet;

        public ProdutoService(TesteAppContext context)
        {
            _context = context;
            _set = _context.Set<ProdutoEntity>();
            _categoriaSet = _context.Set<CategoriaEntity>();
        }

        public async Task<Guid> AdicionarOuAlterarAsync(ProdutoModel produto, CancellationToken cancellationToken = default)
        {
            var categoria = await _categoriaSet.FirstOrDefaultAsync(f => f.Id == produto.CategoriaId, cancellationToken)
                ?? throw new Exception($"A categoria '{produto.CategoriaId}' não foi localizada.");

            ProdutoEntity reg;
            if (produto.Id == Guid.Empty)
            {
                reg = new ProdutoEntity(
                        produto.Descricao,
                        categoria);
                reg.AlterarValor(produto.Valor);

                await _context.AddAsync(
                    reg,
                    cancellationToken);
            }
            else
            {
                reg = await GetProdutoAsync(produto.Id, cancellationToken);
                reg.AlterarDescricao(produto.Descricao);
                reg.AlterarCategoria(categoria);
                reg.AlterarValor(produto.Valor);
                _context.Update(reg);
            }

            await _context.SaveChangesAsync(cancellationToken);
            return reg.Id;
        }

        public async Task ApagarAsync(Guid id, CancellationToken cancellationToken = default)
        {
            _set.Remove(await GetProdutoAsync(id, cancellationToken));
            await _context.SaveChangesAsync();
        }

        private async Task<ProdutoEntity> GetProdutoAsync(Guid id, CancellationToken cancellationToken)=>
            await _set.FirstOrDefaultAsync(f => f.Id == id, cancellationToken)
                ?? throw new Exception($"O produto '{id}' não foi localizado.");
    }
}