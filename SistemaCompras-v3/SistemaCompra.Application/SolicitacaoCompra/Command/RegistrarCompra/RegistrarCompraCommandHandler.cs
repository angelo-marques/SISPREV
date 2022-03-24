using MediatR;
using SistemaCompra.Infra.Data.UoW;
using System.Threading;
using System.Threading.Tasks;
using RegistraCompra = SistemaCompra.Domain.RegistrarCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly RegistraCompra.IRegistrarCompraRepository registrarCompraRepository;

        public RegistrarCompraCommandHandler(RegistraCompra.IRegistrarCompraRepository registrarCompraRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            this.registrarCompraRepository = registrarCompraRepository;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            registrarCompraRepository.RegistrarCompra(request.itens);
            Commit(); 
            return Task.FromResult(true);
        }
      
    }
}
