using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraRepository : ISolicitacaoCompraRepository
    {
        private readonly SistemaCompraContext context;

        public SolicitacaoCompraRepository(SistemaCompraContext context)
        {
            this.context = context;
        }

        public void RegistrarCompra(Domain.SolicitacaoCompraAggregate.SolicitacaoCompra solicitacaoCompra)
        {
            context.Set<Domain.SolicitacaoCompraAggregate.SolicitacaoCompra>().Add(solicitacaoCompra);
        }
    }
}
