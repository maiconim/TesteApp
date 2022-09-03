using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teste.Business.Commands.Categoria;

namespace Teste.WebApi.Controllers
{
    [ApiController]
    [Route("api/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarAsync([FromQuery] ListarCategoriasQuery request, CancellationToken cancellation) =>
            Ok(await _mediator.Send(request, cancellation));

        [HttpGet]
        [Route("obter/{id}")]
        public async Task<IActionResult> ObterAsync(Guid id, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(new CategoriaQuery(id), cancellationToken));

        [HttpGet]
        [Route("total-registros")]
        public async Task<IActionResult> TotalRegistrosAsync(CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(new TotalRegistrosCategoriaQuery(), cancellationToken));

        [HttpPost]
        [Route("adicionar")]
        public async Task<IActionResult> AdicionarAsync(AdicionarCategoriaCommand request, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(request, cancellationToken));

        [HttpPut]
        [Route("alterar")]
        public async Task<IActionResult> AlterarAsync(AtualizarCategoriaCommand request, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(request, cancellationToken));

        [HttpDelete]
        [Route("apagar/{id}")]
        public async Task<IActionResult> ApagarAsync(Guid id, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(new ApagarCategoriaCommand(id), cancellationToken));
    }
}