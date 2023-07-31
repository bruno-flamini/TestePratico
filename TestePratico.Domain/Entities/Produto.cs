using TestePratico.Domain.Validations;

namespace TestePratico.Domain.Entities
{
    public class Produto
    {
        public Produto(string nome, decimal preco, int quantidadeEstoque, DateTime dataCadastro, bool ativo)
        {
            ValidarDominio(nome, preco, quantidadeEstoque);

            DataCadastro = dataCadastro;
            Ativo = true;
        }

        public void Atualizar(int id, string nome, decimal preco, int quantidadeEstoque, DateTime dataCadastro, bool ativo)
        {
            DomainException.Validar(id < 0, $"Id produto inválido. Valor passado: {id}");
            ValidarDominio(nome, preco, quantidadeEstoque);

            Id = id;
            Ativo = ativo;
        }

        private void ValidarDominio(string nome, decimal preco, int quantidadeEstoque)
        {
            DomainException.Validar(preco < 0, $"Valor do produto incorreto. Valor passado: {preco}");
            DomainException.Validar(quantidadeEstoque < 0, $"Valor da quantidade incorreto. Valor passado: {quantidadeEstoque}");

            Nome = nome ?? throw new DomainException($"Campo nome é obrigatório. Valor passado: {nome}");
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; private set; }
    }
}
