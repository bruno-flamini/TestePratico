using TestePratico.Domain.Entities;

namespace TestePratico.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task Inserir(Usuario usuario);
        Task Atualizar(Usuario usuario);
        Task<Usuario> Buscar(int id);
        Task<Usuario> Login(Usuario usuario);

    }
}
