using MediatR;
using Microsoft.EntityFrameworkCore;
using Teste.Business.Commands;
using Teste.Business.Commands.Categoria;
using Teste.Business.Core.Context;
using Teste.Business.Entities;
using Teste.Business.Models;

namespace Teste.Business.CommandQueries
{
    internal class CategoriaQueriesHandlers :
        IRequestHandler<ListarCategoriasQuery, GenericPaginatedResultQuery<CategoriaModel>>,
        IRequestHandler<CategoriaQuery, CategoriaModel>,
        IRequestHandler<TotalRegistrosCategoriaQuery, int>
    {
        private readonly DbSet<CategoriaEntity> _set;

        public CategoriaQueriesHandlers(TesteAppContext context)
        {
            _set = context.Set<CategoriaEntity>();
        }

        public async Task<CategoriaModel> Handle(CategoriaQuery request, CancellationToken cancellationToken) =>
            Parse(await _set.FirstOrDefaultAsync(f => f.Id == request.Id)
                ?? throw new Exception($"Categoria '{request.Id}' não localizada."));

        public async Task<int> Handle(TotalRegistrosCategoriaQuery request, CancellationToken cancellationToken) =>
            await _set.CountAsync(cancellationToken);

        public async Task<GenericPaginatedResultQuery<CategoriaModel>> Handle(ListarCategoriasQuery request, CancellationToken cancellationToken)
        {
            var regTotal = await _set.CountAsync();
            var regs = await _set
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync();

            return new GenericPaginatedResultQuery<CategoriaModel>(Parse(regs), regTotal, request.Draw);
        }

        private CategoriaModel Parse(CategoriaEntity entity) =>
            new(
                entity.Id,
                entity.Nome);

        private IList<CategoriaModel> Parse(IEnumerable<CategoriaEntity> categorias) =>
            categorias
                .Select(s => Parse(s))
                .ToList();
    }
}