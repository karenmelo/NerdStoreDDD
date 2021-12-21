using System;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoEstoqueBaixoEvent : DomainEvent
    {
        public int Quantidade { get; private set; }

        public ProdutoEstoqueBaixoEvent(Guid aggregateId, int quantidade) : base(aggregateId)
        {
            Quantidade = quantidade;
        }
    }
}
