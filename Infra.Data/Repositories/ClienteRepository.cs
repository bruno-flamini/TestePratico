using Dapper;
using System.Collections.Generic;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;

namespace TestePratico.Infra.Data.Repositories
{
    public class ClienteRepository : Database, IClienteRepository
    {
        public async Task Inserir(Cliente cliente)
        {
            var sql = "Insert into cliente (Nome, DataNascimento, TipoPessoa, CpfCnpj, Endereco, DataCadastro, Ativo) values (@Nome, @DataNascimento, @TipoPessoa, @CpfCnpj, @Endereco, @DataCadastro, @Ativo)";
            await _connection.ExecuteAsync(sql, cliente);
        }

        public async Task Atualizar(Cliente cliente)
        {
            var sql = "update cliente set Nome = @Nome, DataNascimento = @DataNascimento, Endereco = @Endereco, Ativo = @Ativo where Id = @Id";
            await _connection.ExecuteAsync(sql, cliente);
        }

        public async Task<IEnumerable<Cliente>> Buscar()
        {
            var sql = "select * from cliente";
            return await _connection.QueryAsync<Cliente>(sql);
        }
    }
}
