using System.ComponentModel.DataAnnotations;

namespace TestePratico.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [MinLength(2, ErrorMessage = "Campo nome deve contêr pelo menos 2 caracteres")]
        [MaxLength(50, ErrorMessage = "Campo nome deve contêr no máximo 50 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo senha é obrigatório")]
        [MinLength(8, ErrorMessage = "Campo senha deve contêr pelo menos 8 caracteres")]
        [MaxLength(20, ErrorMessage = "Campo senha deve contêr no máximo 20 caracteres")]
        public string Senha { get; set; }
        public string Funcao { get; set; }

        public bool Ativo { get; set; }
    }
}
