using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Teste.Business.Core.Context;
using Teste.Business.DomainServices;
using Teste.Business.DomainServices.Categoria;
using Teste.Business.DomainServices.Produto;
using Teste.Business.Services;
using Teste.Business.Services.Categoria;
using Teste.Business.Services.Produto;

namespace Teste
{
    public static class RegisterDependencyInjection
    {
        public static IServiceCollection RegisterDI(this IServiceCollection services)
        {
            services.AddDbContextPool<TesteAppContext>(
               (provider, options) =>
               {
                   var cnn = provider.GetRequiredService<IConfiguration>().GetConnectionString("conexao");
                   options.UseMySql(
                       cnn,
                       ServerVersion.AutoDetect(cnn),
                       sqlOptions =>
                       {
                           sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                       });
               });

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services
                .AddScoped<ICategoriaDomainService, CategoriaDomainService>()
                .AddScoped<IProdutoDomainService, ProdutoDomainService>();

            services
                .AddScoped<ICategoriaService, CategoriaService>()
                .AddScoped<IProdutoService, ProdutoService>();

            return services;
        }
    }
}