using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Teste.AppWeb.Core.Services;

namespace Teste.AppWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRequestService _requestService;

        [BindProperty]
        public int QuantidadeCategorias { get; set; }
        [BindProperty]
        public int QuantidadeProdutos { get; set; }

        public IndexModel(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            QuantidadeCategorias = await ObterTotalRegistrosAsync("api/categoria/total-registros", cancellationToken);
            QuantidadeProdutos = await ObterTotalRegistrosAsync("api/produto/total-registros", cancellationToken);
        }

        private async Task<int> ObterTotalRegistrosAsync(string url, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _requestService.GetAsync(url, cancellationToken);
                if (string.IsNullOrWhiteSpace(result))
                    return 0;
                return Convert.ToInt32(result);
            }
            catch
            {
                return 0;
            }
        }
    }
}