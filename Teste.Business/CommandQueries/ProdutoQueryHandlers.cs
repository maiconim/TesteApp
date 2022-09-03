using MediatR;
using Microsoft.EntityFrameworkCore;
using Teste.Business.Commands;
using Teste.Business.Commands.Produto;
using Teste.Business.Core.Context;
using Teste.Business.Entities;
using Teste.Business.Models;

namespace Teste.Business.CommandQueries
{
    internal class ProdutoQueryHandlers :
        IRequestHandler<ListarProdutoQuery, GenericPaginatedResultQuery<ProdutoModel>>,
        IRequestHandler<ProdutoQuery, ProdutoModel>,
        IRequestHandler<TotalRegistrosProdutoQuery, int>
    {
        private readonly DbSet<ProdutoEntity> _set;

        public ProdutoQueryHandlers(TesteAppContext context)
        {
            _set = context.Set<ProdutoEntity>();
        }

        public async Task<ProdutoModel> Handle(ProdutoQuery request, CancellationToken cancellationToken) =>
            Parse(await _set.Include(i => i.Categoria).FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken)
                ?? throw new Exception($"Produto '{request.Id}' não foi localizado."));

        public async Task<int> Handle(TotalRegistrosProdutoQuery request, CancellationToken cancellationToken) =>
            await _set.CountAsync(cancellationToken);

        public async Task<GenericPaginatedResultQuery<ProdutoModel>> Handle(ListarProdutoQuery request, CancellationToken cancellationToken)
        {
            var regTotal = await _set.CountAsync();
            var regs = await _set
                .Include(i => i.Categoria)
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync();

            return new GenericPaginatedResultQuery<ProdutoModel>(Parse(regs), regTotal, request.Draw);
        }

        private ProdutoModel Parse(ProdutoEntity reg) =>
            new(
                reg.Id,
                reg.Descricao,
                reg.CategoriaID,
                reg.Categoria.Nome,
                reg.Valor);

        private IList<ProdutoModel> Parse(IEnumerable<ProdutoEntity> regs) =>
            regs
                .Select(s => Parse(s))
                .ToList();
    }
}