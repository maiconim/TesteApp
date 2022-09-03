using Microsoft.EntityFrameworkCore;
using Teste.Business.Core.Context;
using Teste.Business.DomainServices;
using Teste.Business.Entities;
using Teste.Business.Models;

namespace Teste.Business.Services.Categoria
{
    internal class CategoriaService : ICategoriaService
    {
        private readonly TesteAppContext _context;
        private readonly DbSet<CategoriaEntity> _set;
        private readonly ICategoriaDomainService _categoriaDomainService;

        public CategoriaService(TesteAppContext context, ICategoriaDomainService categoriaDomainService)
        {
            _context = context;
            _set = context.Set<CategoriaEntity>();
            _categoriaDomainService = categoriaDomainService;
        }

        public async Task ApagarAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var reg = await GetCategoriaAsync(id, cancellationToken);
            _set.Remove(reg);
            await _context.SaveChangesAsync();
        }

        public async Task<Guid> IncluirOuAlterarAsync(CategoriaModel categoria, CancellationToken cancellationToken = default)
        {
            CategoriaEntity reg;
            if (categoria.Id == Guid.Empty)
            {
                reg = new CategoriaEntity(categoria.Nome, _categoriaDomainService);
                await _set.AddAsync(reg);
            }
            else
            {
                reg = await GetCategoriaAsync(categoria.Id, cancellationToken);
                reg.AlterarNome(categoria.Nome, _categoriaDomainService);
                _set.Update(reg);
            }

            await _context.SaveChangesAsync();

            return reg.Id;
        }

        private async Task<CategoriaEntity> GetCategoriaAsync(Guid id, CancellationToken cancellationToken) =>
            await _set.FirstOrDefaultAsync(f => f.Id == id, cancellationToken: cancellationToken)
                    ?? throw new Exception($"Categoria '{id}' não localizada.");
    }
}