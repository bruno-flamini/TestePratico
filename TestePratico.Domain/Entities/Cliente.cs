using TestePratico.Domain.Enums;
using TestePratico.Domain.Utils;
using TestePratico.Domain.Validations;

namespace TestePratico.Domain.Entities
{
    public class Cliente
    {
        public Cliente(string nome, DateTime dataNascimento, TipoPessoa tipoPessoa, string cpfCnpj, string endereco, DateTime dataCadastro, bool ativo)
        {
            ValidarDominio(nome, dataNascimento, endereco);
            ValidarCnpjCpf(tipoPessoa, cpfCnpj);

            DataCadastro = DateTime.Now;
            Ativo = true;
        }

        private void ValidarCnpjCpf(TipoPessoa tipoPessoa, string cpfCnpj)
        {
            DomainException.Validar(string.IsNullOrEmpty(cpfCnpj), $"Campo CPF/CNPJ é obrigatório");

            if (tipoPessoa == TipoPessoa.CNPJ)
                DomainException.Validar(ValidacaoCpfCnpj.ValidarCnpj(cpfCnpj), $"Número CNPJ incorreto. Valor passado: {cpfCnpj}");
            else
                DomainException.Validar(ValidacaoCpfCnpj.ValidarCpf(cpfCnpj), $"Número CPF incorreto. Valor passado: {cpfCnpj}");

            TipoPessoa = tipoPessoa;
            CpfCnpj = cpfCnpj;
        }

        public void Atualizar(int id, string nome, DateTime dataNascimento, string endereco, bool ativo)
        {
            DomainException.Validar(id < 0, $"Id cliente inválido. Valor passado: {id}");
            ValidarDominio(nome, dataNascimento, endereco);

            Id = id;
            Ativo = ativo;
        }

        private void ValidarDominio(string nome, DateTime dataNascimento, string endereco)
        {
            DomainException.Validar(string.IsNullOrEmpty(nome), "Campo nome é obrigatório.");
            DomainException.Validar(nome.Length < 2, "Campo nome deve contêr dois 2 no mínimo.");
            DomainException.Validar(nome.Length > 50, "Campo nome deve contêr 50 caracteres no máximo.");

            DomainException.Validar(string.IsNullOrEmpty(endereco), "Campo endereço é obrigatório.");
            DomainException.Validar(endereco.Length > 50, "Campo endereço deve contêr 50 caracteres no máximo.");

            DomainException.Validar(DateTime.MinValue == dataNascimento, $"Data de nascimento incorreta. Valor passado: {dataNascimento}");

            Nome = nome;
            DataNascimento = dataNascimento;
            Endereco = endereco;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public TipoPessoa TipoPessoa { get; private set; }
        public string CpfCnpj { get; private set; }
        public string Endereco { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; private set; }
    }
}
