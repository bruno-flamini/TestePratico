using TestePratico.Domain.Entities;

namespace TestePratico.Domain.Interfaces
{
    public interface IVendaRepository
    {
        Task<int> InserirVenda(Venda venda);
        Task InserirItemVenda(IEnumerable<ItemVenda> itensVenda);
    }
}
