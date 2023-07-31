using TestePratico.Application.ViewModels;

namespace TestePratico.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task Inserir(UsuarioViewModel usuarioViewModel);
        Task Atualizar(UsuarioViewModel usuarioViewModel);
        Task<UsuarioViewModel> Buscar(int id);
        Task<UsuarioViewModel> Login(UsuarioViewModel usuarioViewModel);
    }
}
