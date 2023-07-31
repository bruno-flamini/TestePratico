using TestePratico.Application.ViewModels;

namespace TestePratico.Application.Interfaces
{
    public  interface IProdutoService
    {
        Task Inserir(ProdutoViewModel produtoViewModel);
        Task Atualizar(ProdutoViewModel produtoViewModel);
        Task<IEnumerable<ProdutoViewModel>> Buscar();
    }
}
