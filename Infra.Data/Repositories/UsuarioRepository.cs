using Dapper;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;

namespace TestePratico.Infra.Data.Repositories
{
    public class UsuarioRepository : Database, IUsuarioRepository
    {
        public async Task Inserir(Usuario usuario)
        {
            var sql = "insert into usuario (Nome, Senha, DataCadastro, Ativo, Funcao) values (@Nome, @Senha, @DataCadastro, @Ativo, @Funcao)";
            await _connection.ExecuteAsync(sql, usuario);
        }

        public async Task Atualizar(Usuario usuario)
        {
            var sql = "update usuario set Nome = @Nome, Senha = @Senha, Ativo = @Ativo where Id = @Id";
            await _connection.ExecuteAsync(sql, usuario);
        }

        public async Task<Usuario> Buscar(int id)
        {
            var sql = "select Id, Nome, Senha, Ativo from usuario where Id = @Id";
            return await _connection.QueryFirstOrDefaultAsync<Usuario>(sql, id);
        }

        public async Task<Usuario> Login(Usuario usuario)
        {
            var sql = "select * from usuario where Nome = @Nome and Senha = @Senha and Ativo = 1";
            return await _connection.QueryFirstOrDefaultAsync<Usuario>(sql, usuario);
        }
    }
}
