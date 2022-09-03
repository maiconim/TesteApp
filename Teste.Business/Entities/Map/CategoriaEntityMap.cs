using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Business.Core.Entity;

namespace Teste.Business.Entities.Map
{
    internal class CategoriaEntityMap : BaseEntityMap<CategoriaEntity>
    {
        public override void Configure(EntityTypeBuilder<CategoriaEntity> builder)
        {
            builder.ToTable("CATEGORIAS");

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(40)
                .IsRequired();

            base.Configure(builder);
        }
    }
}