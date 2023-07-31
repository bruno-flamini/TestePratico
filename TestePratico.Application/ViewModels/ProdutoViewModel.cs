using System.ComponentModel.DataAnnotations;

namespace TestePratico.Application.ViewModels
{
    public class ProdutoViewModel
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "Campo nome obrigatório")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "Campo preço obrigatório")]
        public decimal Preco { get; private set; }

        [Required(ErrorMessage = "Campo quantidade obrigatório")]
        public int QuantidadeEstoque { get; private set; }

        public bool Ativo { get; private set; }
    }
}
