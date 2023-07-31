using TestePratico.Application.ViewModels;

namespace TestePratico.Application.Interfaces
{
    public interface IVendaService
    {
        Task InserirVenda(VendaViewModel vendaViewModel);
        Task InserirItensVenda(IEnumerable<ItemVendaViewModel> itensVendaViewModels);
    }
}
