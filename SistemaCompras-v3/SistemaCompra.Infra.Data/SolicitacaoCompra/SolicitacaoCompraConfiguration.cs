using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Sistema = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    internal class SolicitacaoCompraConfiguration : IEntityTypeConfiguration<Sistema.SolicitacaoCompra>
    {
        public void Configure(EntityTypeBuilder<Sistema.SolicitacaoCompra> builder)
        {
            builder.ToTable("SolicitaCompra");
        
            builder.OwnsOne(c => c.TotalGeral, b => b.Property("Value").HasColumnName("TotalGeral"));
            builder.Property( y => y.Id).HasColumnName("Id");
            builder.Property(y => y.Data).HasColumnName("Data").IsRequired();
            builder.Property(y => y.Situacao).HasColumnName("Situacao").IsRequired();
    
           

        }
       
    }
}
