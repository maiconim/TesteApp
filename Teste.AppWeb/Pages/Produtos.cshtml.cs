using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Teste.AppWeb.Pages
{
    public class ProdutosModel : PageModel
    {
        [BindProperty]
        public string BaseUrl { get; set; }

        [BindProperty]
        public SelectList Categorias { get; set; }

        public ProdutosModel(IConfiguration configuration)
        {
            BaseUrl = configuration["AppTestApi"];
            PopularCategorias();
        }

        private void PopularCategorias()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (HttpRequestMessage m, X509Certificate2? c, X509Chain? chaun, SslPolicyErrors policy) => true;

            using var httClient = new HttpClient(handler, true);
            httClient.BaseAddress = new Uri(BaseUrl);

            var response = httClient.GetAsync("/api/categoria/listar?pageSize=1000").GetAwaiter().GetResult();
            if (!response.IsSuccessStatusCode)
                throw new Exception("Falha ao soliciar dados");

            var content = response.Content.ReadAsStringAsync().Result;
            var model = JsonSerializer.Deserialize<ContentCategoria>(content);

            Categorias = new SelectList(model.Data, "Id", "Nome");
        }

        private class ContentCategoria
        {
            [JsonPropertyName("data")]
            public List<CategoriaModel> Data { get; set; }
        }
        private class CategoriaModel
        {
            [JsonPropertyName("id")]
            public Guid Id { get; set; }
            [JsonPropertyName("nome")]
            public string Nome { get; set; }
        }

        public void OnGet()
        {
        }
    }
}
