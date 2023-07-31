using Dapper;
using TestePratico.Domain.Entities;

namespace TestePratico.Infra.Data.Repositories
{
    public class ProdutoRepository : Database
    {
        public async Task Inserir(Produto produto)
        {
            var sql = "Insert into produto (Nome, Preco, QuantidadeEstoque, DataCadastro, Ativo) values (@Nome, @Preco, @QuantidadeEstoque, @DataCadastro, @Ativo)";
            await _connection.ExecuteAsync(sql, produto);
        }

        public async Task Atualizar(Produto produto)
        {
            var sql = "update produto set Nome = @Nome, Preco = @Preco, QuantidadeEstoque = @QuantidadeEstoque, DataCadastro = @DataCadastro, Ativo = @Ativo where Id = @Id";
            await _connection.ExecuteAsync(sql, produto);
        }

        public async Task<IEnumerable<Produto>> Buscar()
        {
            var sql = "select * from produto";
            return await _connection.QueryAsync<Produto>(sql);
        }
    }
}
