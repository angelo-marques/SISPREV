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
            builder.ToTable("Produto");
           //builder.OwnsOne(c => c.Preco, b => b.Property("Value").HasColumnName("Preco").HasColumnType("decimal").IsRequired());
            builder.HasKey(c => new { c.Id});
            builder.Property(y => y.Preco).HasColumnName("Preco").IsRequired();
            builder.Property(y => y.Id).HasColumnName("Id").IsRequired();
            builder.Property(y => y.Nome).HasColumnName("Nome").IsRequired();
            builder.Property(y => y.Descricao).HasColumnName("Descricao").IsRequired();
            builder.Property(y => y.Categoria).HasColumnName("Categoria").IsRequired();
            builder.Property(y => y.Situacao).HasColumnName("Situacao").IsRequired();

            /*
             Id = Guid.NewGuid();
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            Preco = new Money(preco);
            Categoria = (Categoria) Enum.Parse(typeof(Categoria), categoria);
            Situacao = Situacao.Ativo; 

              */
        }
    }
}
