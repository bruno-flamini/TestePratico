using TestePratico.Domain.Validations;

namespace TestePratico.Domain.Entities
{
    public class ItemVenda
    {
        public ItemVenda(decimal valorBruto, int quantidade, decimal percentualDesconto)
        {
            DomainException.Validar(valorBruto <= 0, $"Preço do produto deve ser maior que R$0,00");
            DomainException.Validar(quantidade < 1, $"Quantidade inválida: Valor passado. {quantidade}");
            DomainException.Validar(percentualDesconto < 0, $"Percentual de desconto inválido. Valor passado: {percentualDesconto}");

            ValorBruto = valorBruto;
            Quantidade = quantidade;
            PercentualDesconto = percentualDesconto;

            CalcularValorLiquido();
        }

        public int Id { get; private set; }
        public int IdVenda { get; private set; }
        public int IdProduto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PercentualDesconto { get; private set; }
        public decimal ValorLiquido { get; private set; }
        public decimal ValorBruto { get; private set; }


        public void CalcularValorLiquido()
        {
            ValorLiquido = ValorBruto - (PercentualDesconto / 100 * ValorBruto);
        }

        public void InserirCodigoVenda(int idVenda)
        {
            DomainException.Validar(idVenda <= 0, $"Código da venda inválido. Valor passado: {idVenda}");

            IdVenda = idVenda;
        }
    }
}
