using AutoMapper;
using TestePratico.Application.Interfaces;
using TestePratico.Application.ViewModels;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;

namespace TestePratico.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task Inserir(ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            await _produtoRepository.Inserir(produto);
        }

        public async Task Atualizar(ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            await _produtoRepository.Atualizar(produto);
        }

        public async Task<IEnumerable<ProdutoViewModel>> Buscar()
        {
            var produtos = await _produtoRepository.Buscar();
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(produtos);
        }
    }
}
