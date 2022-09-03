using MediatR;
using Teste.Business.Models;

namespace Teste.Business.Commands.Categoria
{
    public class CategoriaQuery : IRequest<CategoriaModel>
    {
        public Guid Id { get; }

        public CategoriaQuery(Guid id)
        {
            Id = id;
        }
    }
}