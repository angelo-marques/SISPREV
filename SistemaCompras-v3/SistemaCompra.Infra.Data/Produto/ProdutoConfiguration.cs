using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCompra.Domain.Core.Model;
using System;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;

namespace SistemaCompra.Infra.Data.Produto
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<ProdutoAgg.Produto>
    {
        public void Configure(EntityTypeBuilder<ProdutoAgg.Produto> builder)
        {
      
            builder.ToTable("Produtos");
            builder.HasKey(c => new { c.Id});
            builder.Property(y => y.Id).HasColumnName("Id").IsRequired();
            builder.Property(y => y.Nome).HasColumnName("Nome");
            builder.Property(y => y.Descricao).HasColumnName("Descricao");
            builder.Property(y => y.Categoria).HasColumnName("Categoria");
            builder.Property(y => y.Preco).HasColumnName("Preco");
            builder.Property(y => y.Situacao).HasColumnName("Situacao");
        }
    }
}
