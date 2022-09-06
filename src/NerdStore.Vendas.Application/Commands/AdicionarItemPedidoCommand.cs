using FluentValidation;
using NerdStore.Core.Messages;

namespace NerdStore.Vendas.Application.Commands
{
    public class AdicionarItemPedidoCommand : Command
    {
        public AdicionarItemPedidoCommand(Guid clientId, Guid produtoId, string nome, int quantidade, decimal valorUnitario)
        {
            ClientId = clientId;
            ProdutoId = produtoId;
            Nome = nome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public Guid ClientId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarItemPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AdicionarItemPedidoValidation : AbstractValidator<AdicionarItemPedidoCommand>
    {
        public AdicionarItemPedidoValidation()
        {
            RuleFor(c => c.ClientId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente invalido");

            RuleFor(c => c.ProdutoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do produto invalido");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do produto nao foi informado");

            RuleFor(c => c.Quantidade)
                .GreaterThan(0)
                .WithMessage("A quantidade minima de um item e 1");

            RuleFor(c => c.Quantidade)
                .LessThan(15)
                .WithMessage("A quantidade maxima de um item e 15");

            RuleFor(c => c.ValorUnitario)
                .GreaterThan(0)
                .WithMessage("O valor do item precisa ser maior que 0");            
        }
    }
}
