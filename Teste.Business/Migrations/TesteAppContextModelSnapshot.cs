// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Teste.Business.Core.Context;

#nullable disable

namespace Teste.Business.Migrations
{
    [DbContext(typeof(TesteAppContext))]
    partial class TesteAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Teste.Business.Entities.CategoriaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("ID");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("NOME");

                    b.HasKey("Id");

                    b.ToTable("CATEGORIAS", (string)null);
                });

            modelBuilder.Entity("Teste.Business.Entities.ProdutoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("ID");

                    b.Property<Guid>("CategoriaID")
                        .HasColumnType("char(36)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("DESCRICAO");

                    b.Property<decimal>("Valor")
                        .HasColumnType("DECIMAL(18,2)")
                        .HasColumnName("VALOR");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaID");

                    b.ToTable("PRODUTOS", (string)null);
                });

            modelBuilder.Entity("Teste.Business.Entities.ProdutoEntity", b =>
                {
                    b.HasOne("Teste.Business.Entities.CategoriaEntity", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_PRODUTO_CATEGORIA");

                    b.Navigation("Categoria");
                });
#pragma warning restore 612, 618
        }
    }
}
