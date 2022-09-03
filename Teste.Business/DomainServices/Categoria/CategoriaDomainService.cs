using Microsoft.EntityFrameworkCore;
using Teste.Business.Core.Context;
using Teste.Business.Entities;

namespace Teste.Business.DomainServices.Categoria
{
    internal class CategoriaDomainService : ICategoriaDomainService
    {
        public readonly TesteAppContext _context;

        public CategoriaDomainService(TesteAppContext context)
        {
            _context = context;
        }

        public async Task<bool> NomeJaUtilizadoAsync(CategoriaEntity categoria, string nome) =>
            await _context.Set<CategoriaEntity>()
                .Where(w => w.Nome.Contains(nome.Trim()))
                .Where(w => w.Id != categoria.Id)
                .AnyAsync();
    }
}