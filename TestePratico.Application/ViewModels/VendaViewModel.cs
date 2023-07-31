using System.ComponentModel.DataAnnotations;

namespace TestePratico.Application.ViewModels
{
    public class VendaViewModel
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "Venda deve possuir um usuário id")]
        public int UsuarioId { get; private set; }

        public decimal Valor { get; private set; }

        public IEnumerable<ItemVendaViewModel> ItensVendaViewModels { get; private set; }
    }
}
