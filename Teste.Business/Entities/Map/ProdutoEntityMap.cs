using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Business.Core.Entity;

namespace Teste.Business.Entities.Map
{
    internal class ProdutoEntityMap : BaseEntityMap<ProdutoEntity>
    {
        public override void Configure(EntityTypeBuilder<ProdutoEntity> builder)
        {
            builder.ToTable("PRODUTOS");

            builder.Property(p => p.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Valor)
                .HasColumnName("VALOR")
                .HasColumnType("DECIMAL(18,2)")
                .IsRequired();

            builder.HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.CategoriaID)
                .HasConstraintName("FK_PRODUTO_CATEGORIA")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            base.Configure(builder);
        }
    }
}