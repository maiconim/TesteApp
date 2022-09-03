using MediatR;
using Teste.Business.Commands.Categoria;
using Teste.Business.Services;

namespace Teste.Business.CommandHandlers
{
    internal class CategoriaHandler :
        IRequestHandler<AdicionarCategoriaCommand, Guid>,
        IRequestHandler<ApagarCategoriaCommand>,
        IRequestHandler<AtualizarCategoriaCommand>
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaHandler(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public async Task<Guid> Handle(AdicionarCategoriaCommand request, CancellationToken cancellationToken) =>
            await _categoriaService.IncluirOuAlterarAsync(
                new Models.CategoriaModel(Guid.Empty, request.Nome), 
                cancellationToken);

        public async Task<Unit> Handle(AtualizarCategoriaCommand request, CancellationToken cancellationToken)
        {
            await _categoriaService.IncluirOuAlterarAsync(
                new Models.CategoriaModel(request.Id, request.Nome), 
                cancellationToken);

            return default;
        }

        public async Task<Unit> Handle(ApagarCategoriaCommand request, CancellationToken cancellationToken)
        {
            await _categoriaService.ApagarAsync(request.Id, cancellationToken);

            return default;
        }
    }
}