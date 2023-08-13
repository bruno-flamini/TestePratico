using System.Security.Cryptography;
using System.Text;
using TestePratico.Domain.Utils;
using TestePratico.Domain.Validations;

namespace TestePratico.Domain.Entities
{
    public class Usuario
    {
        public Usuario(string nome, string senha)
        {
            ValidarDominio(nome, senha);

            DataCadastro = DateTime.Now;
            Ativo = true;
            Funcao = "Vendedor";
        }

        public void Atualizar(int id, string nome, string senha, bool ativo)
        {
            DomainException.Validar(id < 0, $"Id usuário inválido. Valor passado: {id}");
            ValidarDominio(nome, senha);

            Id = id;
            Ativo = ativo;
        }

        private void ValidarDominio(string nome, string senha)
        {
            DomainException.Validar(string.IsNullOrEmpty(nome), $"Campo nome é obrigatório");
            DomainException.Validar(nome.Length < 2, $"Nome digitado curto demais. Valor mínimo de 2 caracteres");
            DomainException.Validar(nome.Length > 50, $"Campo nome excedeu o limite de 50 caracteres");
            DomainException.Validar(string.IsNullOrEmpty(senha), $"Campo senha é obrigatório");
            DomainException.Validar(SenhaValidacao.ValidarSenha(senha), $"Senha fraca. O campo senha deve ser preenchido com pelo menos um número, uma letra maiúscula e oito caracteres. Valor passado: {senha}");
            DomainException.Validar(senha.Length > 20, $"Senha digitada excedeu o limite de 20 caracteres");

            Nome = nome;
            Senha = senha;
        }

        public int Id { get; set; }
        public string Nome { get; private set; } = string.Empty;
        public string Senha { get; private set; } = string.Empty;
        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; private set; }
        public string Funcao { get; private set; }

        public void CriptografarSenha()
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(Senha);

            array = hash.ComputeHash(array);

            var valorCodificado = new StringBuilder();

            foreach (var item in array)
            {
                valorCodificado.Append(item.ToString("@1!%#"));
            }

            Senha = valorCodificado.ToString();
        }
    }
}
