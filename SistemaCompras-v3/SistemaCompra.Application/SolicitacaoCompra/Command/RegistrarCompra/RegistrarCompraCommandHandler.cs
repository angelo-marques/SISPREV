using MediatR;
using SistemaCompra.Domain.Core;
using SistemaCompra.Infra.Data.UoW;
using System.Threading;
using System.Threading.Tasks;
using SolicitaCompra = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly SolicitaCompra.ISolicitacaoCompraRepository solicitarCompraRepository;


        public RegistrarCompraCommandHandler(SolicitaCompra.ISolicitacaoCompraRepository registrarCompraRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            this.solicitarCompraRepository = registrarCompraRepository;

        }
 
        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            if(request.Itens.Count < 1)
            {
                throw new BusinessRuleException("Quantidade tem que ser maior que 0!");
            }

            if(request.UsuarioSolicitante == null)
            {
                throw new BusinessRuleException("Falta informar o solicitante");
            }

            if (request.NomeFornecedor == null)
            {
                throw new BusinessRuleException("Falta informar o fornecedor");
            }

            var solicitaCompra = new SolicitaCompra.SolicitacaoCompra(request.UsuarioSolicitante, request.NomeFornecedor);

            solicitaCompra.RegistrarCompra(request.Itens, request.CondicaoPagamento);
            solicitarCompraRepository.RegistrarCompra(solicitaCompra);
            Commit();
            PublishEvents(solicitaCompra.Events);

            return Task.FromResult(true);

          
        }

    }
}
