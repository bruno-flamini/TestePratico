using TestePratico.Domain.Entities;

namespace TestePratico.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task Inserir(Cliente cliente);
        Task Atualizar(Cliente cliente);
        Task<IEnumerable<Cliente>> Buscar();
    }
}
