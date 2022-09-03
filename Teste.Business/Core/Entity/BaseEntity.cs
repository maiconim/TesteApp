namespace Teste.Business.Core.Entity
{
    internal class BaseEntity
    {
        public Guid Id { get; protected set; } = Guid.Empty;
    }
}