using Dapper;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;

namespace TestePratico.Infra.Data.Repositories
{
    public class VendaRepository : Database, IVendaRepository
    {
        public async Task<int> InserirVenda(Venda venda)
        {
            var sql = @"insert into venda (UsuarioId, DataVenda) values (@UsuarioId, @DataVenda);
                        SELECT CAST(SCOPE_IDENTITY() as int)";
            return await _connection.QuerySingleAsync<int>(sql, venda);
        }

        public async Task InserirItemVenda(IEnumerable<ItemVenda> itensVenda)
        {
            var sql = @"insert into itemvenda (IdVenda, IdProduto, Quantidade, PercentualDesconto, ValorLiquido)
                               values (@IdVenda, @IdProduto, @Quantidade, @PercentualDesconto, @ValorLiquido)";
            await _connection.ExecuteAsync(sql, itensVenda);
        }
    }
}
