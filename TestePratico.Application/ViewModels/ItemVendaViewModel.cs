using System.ComponentModel.DataAnnotations;

namespace TestePratico.Application.ViewModels
{
    public class ItemVendaViewModel
    {
        public int Id { get; private set; }
        
        [Required(ErrorMessage = "Id inválido")]
        public int IdProduto { get; private set; }

        [Required(ErrorMessage = "Campo quantidade é obrigatório")]
        public int Quantidade { get; private set; }

        public decimal PercentualDesconto { get; private set; }
        public decimal ValorBruto { get; private set; }
    }
}
