using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text.Json.Serialization;
using Teste.AppWeb.Core.Services;

namespace Teste.AppWeb.Pages
{
    public class CategoriasModel : PageModel
    {
        [BindProperty]
        public string BaseUrl { get; set; }

        public CategoriasModel(IConfiguration configuration)
        {
            BaseUrl = configuration["AppTestApi"];
        }

        public async void OnGet() { }
    }
}