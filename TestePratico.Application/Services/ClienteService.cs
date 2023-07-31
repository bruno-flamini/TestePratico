using AutoMapper;
using TestePratico.Application.Interfaces;
using TestePratico.Application.ViewModels;
using TestePratico.Domain.Entities;
using TestePratico.Domain.Interfaces;

namespace TestePratico.Application.Services
{
    public class ClienteService : IClienteService
    {
        IClienteRepository _clienteRepository;
        IMapper _mapper;

        public ClienteService(IMapper mapper, IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        public async Task Inserir(ClienteViewModel clienteViewModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            await _clienteRepository.Inserir(cliente);
        }

        public async Task Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            await _clienteRepository.Atualizar(cliente);
        }

        public async Task<IEnumerable<ClienteViewModel>> Buscar()
        {
            var clientes = await _clienteRepository.Buscar();

            if (clientes is null)
            {
                throw new ApplicationException("Entidade não foi encontrada!");
            }

            return _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);
        }
    }
}
