using NerdStore.Core.DomainObjects;

namespace NerdStore.Vendas.Domain.Entities
{
    public class PedidoItem : Entity
    {

        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string ProtudoNome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        //EF Relational
        public Pedido Pedido { get; private set; }

        public PedidoItem(Guid produtoId, string protudoNome, int quantidade, decimal valorUnitario)
        {
            ProdutoId = produtoId;
            ProtudoNome = protudoNome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        protected PedidoItem() { }

        internal void AssociarPedido(Guid pedidoId)
        {
            ProdutoId = pedidoId;
        }

        public decimal CalcularValor()
        {
            return Quantidade * ValorUnitario;
        }

        internal void AdicionarUnidades(int unidades)
        {
            Quantidade += unidades;
        }

        internal void AtualizarUnidades(int unidades)
        {
            Quantidade = unidades;
        }

        public override bool EhValido()
        {
            return true;
        }
    }
}
