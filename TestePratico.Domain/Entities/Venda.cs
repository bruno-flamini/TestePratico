using TestePratico.Domain.Validations;

namespace TestePratico.Domain.Entities
{
    public class Venda
    {
        public Venda(int usuarioId, decimal valor)
        {
            DomainException.Validar(usuarioId < 0, $"Usuário id inválido. Valor passado: {usuarioId}");
            DomainException.Validar(valor <= 0, $"Valor da venda deve ser maior que R$0,00");

            UsuarioId = usuarioId;
            DataVenda = DateTime.Now;
            Valor = valor;
        }

        public int Id { get; private set; }
        public int UsuarioId { get; private set; }
        public DateTime DataVenda { get; private set; }
        public decimal Valor { get; private set; }
    }
}
