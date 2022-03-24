using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Domain.RegistrarCompraAggregate
{
    public interface IRegistrarCompraRepository
    {
        void RegistrarCompra(IEnumerable<Item> itens);
    }
}
