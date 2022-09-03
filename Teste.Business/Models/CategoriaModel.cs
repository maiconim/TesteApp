namespace Teste.Business.Models
{
    public class CategoriaModel
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }

        public CategoriaModel(Guid id,string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
