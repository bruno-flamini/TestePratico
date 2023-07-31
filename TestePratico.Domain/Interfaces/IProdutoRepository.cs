using TestePratico.Domain.Entities;

namespace TestePratico.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task Inserir(Produto produto);
        Task Atualizar(Produto produto);
        Task<IEnumerable<Produto>> Buscar();
    }
}
