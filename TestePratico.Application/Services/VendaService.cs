using AutoMapper;
using TestePratico.Application.Interfaces;
using TestePratico.Application.ViewModels;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;

namespace TestePratico.Application.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IMapper _mapper;

        public VendaService(IVendaRepository vendaRepository, IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _mapper = mapper;
        }

        public async Task InserirVenda(VendaViewModel vendaViewModel)
        {
            var venda = _mapper.Map<Venda>(vendaViewModel);
            await _vendaRepository.InserirVenda(venda);
        }

        public async Task InserirItensVenda(IEnumerable<ItemVendaViewModel> itensVendaViewModels)
        {
            var itensVenda = _mapper.Map<IEnumerable<ItemVenda>>(itensVendaViewModels);
            await _vendaRepository.InserirItemVenda(itensVenda);
        }
    }
}
