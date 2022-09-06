using NerdStore.Core.DomainObjects;
using System;

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
