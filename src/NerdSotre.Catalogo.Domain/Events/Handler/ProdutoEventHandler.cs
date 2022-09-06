using MediatR;
using NerdStore.Catalogo.Domain.Interfaces.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain.Events.Handler
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoEstoqueBaixoEvent>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoEventHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Handle(ProdutoEstoqueBaixoEvent notification, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ObterPorId(notification.AggregateId);

            //Enviar um email para aquisição de mais produtos.
        }
    }
}
