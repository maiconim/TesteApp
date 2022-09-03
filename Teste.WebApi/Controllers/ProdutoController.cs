using MediatR;
using Microsoft.AspNetCore.Mvc;
using Teste.Business.Commands.Produto;

namespace Teste.WebApi.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarAsync([FromQuery] ListarProdutoQuery request, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(request, cancellationToken));

        [HttpGet]
        [Route("obter/{id}")]
        public async Task<IActionResult> ObterAsync(Guid id, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(new ProdutoQuery(id), cancellationToken));

        [HttpGet]
        [Route("total-registros")]
        public async Task<IActionResult> TotalRegistrosAsync(CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(new TotalRegistrosProdutoQuery(), cancellationToken));

        [HttpPost]
        [Route("adicionar")]
        public async Task<IActionResult> AdicionarAsync(AdicionarProdutoCommand request, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(request, cancellationToken));

        [HttpPut]
        [Route("alterar")]
        public async Task<IActionResult> AlterarAsync(AlterarProdutoCommand request, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(request, cancellationToken));

        [HttpDelete]
        [Route("apagar/{id}")]
        public async Task<IActionResult> ApagarAsync(Guid id, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(new ApagarProdutoCommand(id), cancellationToken));
    }
}