using NerdStore.Core.DomainObjects;
using NerdStore.Vendas.Domain.Enums;

namespace NerdStore.Vendas.Domain.Entities
{
    public class Pedido : Entity, IAggregateRoot
    {
        public int Codigo { get; private set; }
        public Guid ClientId { get; private set; }
        public Guid? VoucherId { get; private set; }
        public bool VoucherUtilizado { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public PedidoStatus PedidoStatus { get; private set; }

        private readonly List<PedidoItem> _pedidoItens;

        public Pedido(Guid clientId, bool voucherUtilizado, decimal desconto, decimal valorTotal)
        {
            ClientId = clientId;
            VoucherUtilizado = voucherUtilizado;
            Desconto = desconto;
            ValorTotal = valorTotal;
            _pedidoItens = new List<PedidoItem>();
        }

        public Pedido()
        {
            _pedidoItens = new List<PedidoItem>();
        }

        public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItens;

        //EF Relational
        public virtual Voucher Voucher { get; private set; }


        public void CalcularValorTotalDesconto()
        {
            if (!VoucherUtilizado) return;

            decimal desconto = 0;
            var valor = ValorTotal;

            if (Voucher.TipoDescontoVoucher == TipoDescontoVoucher.Porcentagem)
            {
                if (Voucher.Percentual.HasValue)
                {
                    desconto = (valor * Voucher.Percentual.Value) / 100;
                    valor -= desconto;
                }
            }
            else
            {
                if (Voucher.ValorDesconto.HasValue)
                {
                    desconto = Voucher.ValorDesconto.Value;
                    valor -= desconto;
                }
            }

            ValorTotal = valor < 0 ? 0 : valor;
            Desconto = desconto;
        }

        public void CalcularValorPedido()
        {
            ValorTotal = PedidoItems.Sum(p => p.CalcularValor());
            CalcularValorTotalDesconto();
        }

        public bool PedidoItemExistente(PedidoItem item)
        {
            return _pedidoItens.Any(p => p.ProdutoId == item.ProdutoId);
        }


    }
}
