using TestePratico.Application.ViewModels;

namespace TestePratico.Application.Interfaces
{
    public interface IClienteService
    {
        Task Inserir(ClienteViewModel usuarioViewModel);
        Task Atualizar(ClienteViewModel usuarioViewModel);
        Task<IEnumerable<ClienteViewModel>> Buscar();
    }
}
