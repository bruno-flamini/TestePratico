using System.ComponentModel.DataAnnotations;
using TestePratico.Domain.Enums;

namespace TestePratico.Application.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [MinLength(2)]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo data de nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }
        public TipoPessoa TipoPessoa { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "Campo endereço é obrigatório")]
        [MaxLength(50)]
        public string Endereco { get; set; }

        public bool Ativo { get; set; }
    }
}
