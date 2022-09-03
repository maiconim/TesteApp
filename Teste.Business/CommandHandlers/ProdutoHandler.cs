using MediatR;
using Teste.Business.Commands.Produto;
using Teste.Business.Models;
using Teste.Business.Services;

namespace Teste.Business.CommandHandlers
{
    internal class ProdutoHandler :
        IRequestHandler<AdicionarProdutoCommand, Guid>,
        IRequestHandler<AlterarProdutoCommand>,
        IRequestHandler<ApagarProdutoCommand>
    {
        private readonly IProdutoService _produtoService;

        public ProdutoHandler(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public async Task<Unit> Handle(ApagarProdutoCommand request, CancellationToken cancellationToken)
        {
            await _produtoService.ApagarAsync(request.Id, cancellationToken);
            return default;
        }

        public async Task<Unit> Handle(AlterarProdutoCommand request, CancellationToken cancellationToken)
        {
            await _produtoService.AdicionarOuAlterarAsync(
                new ProdutoModel(
                    request.Id,
                    request.Descricao,
                    request.CategoriaID,
                    request.Valor),
                cancellationToken);
            return default;
        }

        public async Task<Guid> Handle(AdicionarProdutoCommand request, CancellationToken cancellationToken) =>
            await _produtoService.AdicionarOuAlterarAsync(new ProdutoModel(
                    Guid.Empty,
                    request.Descricao,
                    request.CategoriaId,
                    request.Valor),
                cancellationToken);
    }
}