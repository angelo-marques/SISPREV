using SistemaCompra.Domain.ProdutoAggregate;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public interface ISolicitacaoCompraRepository
    {
        void RegistrarCompra(SolicitacaoCompra solicitacaoCompra);
    }
}
